import {USER_LOGGED_IN} from '../constants/actionTypes';
import api from '../api'

export const userLoggedIn = (user) => ({
    type: USER_LOGGED_IN,
    user
})

export const login = credentials => dispatach => api
    .user
    .login(credentials)
    .then(user => dispatach(userLoggedIn(user)))
    ;