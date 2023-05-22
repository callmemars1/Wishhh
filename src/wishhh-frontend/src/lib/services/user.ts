import {RequestValidationError, redirect} from '../utils/requestUtilities';
import {
    userId, 
    username, 
    displayName, 
    imageUri
} from '$lib/utils/stores'

export async function updateUserDataStores(){
    let result = await fetch('/api/users/info', {
        credentials: "include"
    })
    
    if (!result.ok) 
        redirect("/error?status=500")

    let userData = await result.json()
    
    userId.set(userData.id)
    username.set(userData.username)
    displayName.set(userData.displayName)
    imageUri.set(userData.imageUri)
}

export async function requestUserInfo(): Promise<UserData | undefined> {
    let result = await fetch('/api/users/info', {
        credentials: "include"
    })
    if (!result.ok)
        return undefined

    let body = await result.json()
    return {
        id: body.id,
        username: body.username,
        displayName: body.displayName,
        imageUri: body.imageUri
    }
}

export async function requestWishlists(): Promise<WishlistData[] | undefined> {
    let result = await fetch('/api/wishlists', {
        credentials: "include"
    })

    if (!result.ok)
        return undefined
    
    let body = await result.json()
    
    return body;
}

export async function changeName(name: string): Promise<void> {
    let result = await fetch('/api/users/set-name', {
        body: JSON.stringify({displayName: name}),
        headers: {
            'Content-Type': 'application/json'
        },
        method: "POST",
        credentials: "include"
    })

    if (!result.ok) {
        let body = await result.json()
        throw new RequestValidationError(body.title, body.errors)
    }
}

export async function setAvatar(photo: File): Promise<void> {
    let result = await fetch('/api/users/set-avatar', {
        body: JSON.stringify({displayName: name}),
        method: "POST",
        credentials: "include"
    })

    if (!result.ok) {
        let body = await result.json()
        throw new RequestValidationError(body.title, body.errors)
    }
}

export class UserData {
    id!: string
    username!: string
    displayName!: string
    imageUri!: string
}

export class WishlistData {
    name!: string
    imageUri!: string
    private!: boolean
}