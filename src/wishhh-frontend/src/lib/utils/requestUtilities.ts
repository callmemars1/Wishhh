import { browser } from '$app/environment';
import { redirect as svelteRedirect } from '@sveltejs/kit';
import {goto} from '$app/navigation';

export async function postJson(url: string, body: string) {
    return await fetch(url, {
        method: 'POST',
        credentials: "same-origin",
        headers: {
            'Content-Type': 'application/json'
        },
        body: body
    })
}

export async function redirect(path: string){
    if (browser)
        await goto(path);
    else throw svelteRedirect(307, path);
}

export class RequestValidationError extends Error {
    private _errors: Map<string, string[]> = new Map<string, string[]>();

    constructor(title: string, errors: Map<string, string[]>) {
        super(title);
        this._errors = errors
    }

    public getErrors(): ReadonlyMap<string, string[]> {
        return this._errors;
    }
}

export const createSingleMessage = (messages: string[]) => {
    let finalMessage = "";

    if (messages === undefined)
        return finalMessage;

    messages.forEach((item, index) => {
        finalMessage = finalMessage.concat(item + ' ');
    });
    return finalMessage;
}