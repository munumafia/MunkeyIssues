import {HttpClient} from 'aurelia-http-client';
import {Router} from 'aurelia-router';

export class Login {
	static inject() { return [HttpClient, Router]; }

	constructor(http, router) {
		this.http = http;
		this.router = router;
		this.username = "";
		this.password = "";
	}

	activate() {
		// ...
	}

	canDeactivate() {
		return true;
	}

	login() {
		alert(`Username: ${this.username}`);
	}
}
