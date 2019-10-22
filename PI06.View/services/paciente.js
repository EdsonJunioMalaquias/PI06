import { http } from './config'

export default {
    getByCpf:(cpf) => {
        return http.get(`/api/paciente/cpf/${cpf}`)
    },
    findConsultasByPaciente:(idPaciente) => {
        return http.get(`/api/consulta/${idPaciente}`)
    }
}