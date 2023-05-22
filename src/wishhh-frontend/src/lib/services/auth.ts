import {postJson, RequestValidationError, redirect} from '../utils/requestUtilities';

export async function ensureAuthenticated() {
    let result = await fetch('/api/auth/auth-check', {
        credentials: "include"
    })

    if (!result.ok)
        redirect('/error?status=401')
}

export async function signOut() {
    await fetch('/api/auth/sign-out', {
        method: "POST",
        credentials: "include"
    })
}

export async function sendSignUpRequest(request: SignupRequest): Promise<SignupResult> {
    let result = await postJson('/api/auth/sign-up', JSON.stringify(request));
    if (!result.ok) {
        let body = await result.json()
        throw new RequestValidationError(body.title, body.errors)
    }

    let body = await result.json()
    return body.userId;
}

export async function sendSignInRequest(request: SigninRequest): Promise<void> {
    let result = await postJson('/api/auth/sign-in', JSON.stringify(request));
    if (!result.ok) {
        let body = await result.json();
        throw new RequestValidationError(body.title, body.errors);
    }
}

export async function trySignUpAndThenSignIn(request: SignupRequest) {
    let signUpResult = await sendSignUpRequest(request);
    let signInResult = await sendSignInRequest(new SigninRequest(request.username, request.password));
}

export class SignupRequest {
    username!: string
    password!: string
    displayName!: string

    constructor(
        username: string,
        password: string,
        displayName: string) {
        this.username = username
        this.password = password
        this.displayName = displayName
    }
}


export class SigninRequest {
    username!: string
    password!: string

    constructor(
        username: string,
        password: string) {
        this.username = username
        this.password = password
    }

}

type SignupResult = string | undefined;