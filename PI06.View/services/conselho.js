import { http } from './config'

export default {
    get:(id) => {
        return http.get(`/api/conselho/${id}`)
    }, 
    get:() => {
        return http.get(`/api/conselho/`)
    },
    post:(obj) => {
        return http.post(`/api/conselho/`,obj)
    },
    put:(obj) => {
        return http.post(`/api/conselho/`,obj)
    }
}