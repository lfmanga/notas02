import moment from 'moment'
import axios from 'axios'

const ACCESS_TOKEN = 'accessToken'
const CREATED = 'created'
const EXPIRATION = 'expiration'

export const signIn = (d) => {
    localStorage.setItem(ACCESS_TOKEN, d.accessToken)
    localStorage.setItem(CREATED, d.created)
    localStorage.setItem(EXPIRATION, d.expiration)
    return d.authenticated
}

export const signOut = () => {
    localStorage.removeItem(ACCESS_TOKEN)
    localStorage.removeItem(CREATED)
    localStorage.removeItem(EXPIRATION)
}

export const isAuthenticated = () => {
    let accessToken = localStorage.getItem(ACCESS_TOKEN)
    let expiration = localStorage.getItem(EXPIRATION)
    return accessToken && (moment().isBefore(expiration))
}

export const AuthHttpClient = () => {
    return axios.create({
        headers: {
            authorization: 'Bearer ' + localStorage.getItem(ACCESS_TOKEN)
        }
    })
}