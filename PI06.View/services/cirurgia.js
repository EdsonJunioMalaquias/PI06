import { http } from './config'

export default {
    get:(id) => {
        return http.get(`/api/cirurgia/${id}`)
    }, 
    get:() => {
        return http.get(`/api/cirurgia/`)
    },
    post:(obj) => {
        return http.post(`/api/cirurgia/`,obj)
    },
    put:(obj) => {
        return http.put(`/api/cirurgia/`,obj)
    }
}