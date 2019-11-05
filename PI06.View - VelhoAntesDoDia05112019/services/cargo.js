import { http } from './config'

export default {
    get:(id) => {
        return http.get(`/api/cargo/${id}`)
    }, 
    get:() => {
        return http.get(`/api/cargo/`)
    },
    post:(obj) => {
        return http.post(`/api/cargo/`,obj)
    },
    put:(obj) => {
        return http.put(`/api/cargo/`,obj)
    }
}