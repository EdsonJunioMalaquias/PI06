import { http } from './config'

export default {
    get:(id) => {
        return http.get(`/api/tipoExame/${id}`)
    }, 
    get:() => {
        return http.get(`/api/tipoExame/`)
    },
    post:(obj) => {
        return http.post(`/api/tipoExame/`,obj)
    },
    put:(obj) => {
        return http.post(`/api/tipoExame/`,obj)
    }
}