import {Router} from 'aurelia-router';
import bootstrap from 'bootstrap';

export class App {
  static inject() { return [Router]; }
  constructor(router) {
    this.router = router;
    this.router.configure(config => {
      config.title = 'MunkeyIssues';
      //config.addPipelineStep('authorize', AuthorizeStep);
      config.map([
        { route: ['','welcome'],  moduleId: './welcome',      nav: true,  title:'Welcome' },
        { route: 'flickr',        moduleId: './flickr',       nav: true },
        { route: 'child-router',  moduleId: './child-router', nav: true,  title:'Child Router' },
		    { route: 'login',         moduleId: './login',        nav: true,  title:'Login' },
        { route: 'register',      moduleId: './register',     nav: false, title:'Register' }
      ]);
    });
  }
}

class AuthorizeStep {
    static inject() { return []; }

    constructor() {
    }

    run(routingContext, next) {
        let authKey = "bearer-token";
        let token = localStorage.getItem(authKey);

        if (!token) {
            return next.cancel(new Redirect("login"));
        }
    }
}
