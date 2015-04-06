import {HttpClient} from 'aurelia-http-client';
import {Config} from '../config';

export class AuthService {
  static inject() { return [HttpClient, Config]; }

  constructor(httpClient, config) {
    this.httpClient = httpClient;
    this.config = config;

    // Any way to do this just once for the app?
    let authToken = localStorage.getItem(config.authTokenKey);
    this.httpClient.configure(config => {
      config.withBaseUri(this.config.apiUrl);
      config.withHeader('Authorization', authToken);
      config.withHeader('Accept', 'application/json');
      config.withHeader('Content-Type', 'application/json');
    });
  }

  getToken(user) {
    let request = {
      grant_type: 'client_credentials',
      username: user.emailAddress,
      password: user.password
    };

    let content = JSON.stringify(request);
    return this.httpClient.post('auth/token', content);
  }

  register(user) {
    let content = JSON.stringify(user);
    return this.httpClient.post('account/register', content)
  }
}
