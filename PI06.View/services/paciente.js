import { http } from './config'

export default {
    listar:(cpf) => {
        return http.get(`/api/funcionario/cpf/${cpf}`)
    }
}