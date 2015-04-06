import {AuthService} from './lib/auth-service';

export class Register {
  static inject() { return [AuthService]; }

  constructor(authService) {
    this.authService = authService;

    // Model properties
    this.firstName = '';
    this.lastName = '';
    this.emailAddress = '';
    this.password = '';
    this.error = null;
  }

  getAuthToken(user) {
    this.authService.getToken(user)
      .then(
        success => {
          this.error = null;
          console.log(success);
        },

        error => {
          this.error = "There was an error logging in after registering";
          console.log(error);
        }
      );
  }

  register() {
    let user = {
      firstName: this.firstName,
      lastName: this.lastName,
      emailAddress: this.emailAddress,
      password: this.password
    };

    this.authService.register(user)
      .then(
        success => {
          this.error = null;
          this.getAuthToken(user);
        },

        error => {
          this.error = "There was an unknown error registering";
          console.log(error);
        }
      );
  }
}
