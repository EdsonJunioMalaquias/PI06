
<template>
  <div>
    <div class="form">
        <Header title="Consulta" hideToggle="false" hideUserDropdown="false" />
            <div>
                <div class="container">
                
                    <div class="row">
                        <div class="col-md">
                            <form>
                                <h4>Dados Pessoais</h4>
                                <label>Nome</label>
                                <input type="text" readonly :value="resultadosPessoais.pessoa.nome">
                                <label>SUS:</label>
                                <input type="number" readonly :value="resultadosPessoais.pessoa.sus">
                                <label>Idade</label>
                                <input type="number" readonly :value="idade">
                                <label>Peso</label>
                                <input type="number" placeholder="Peso">
                                <label>Altura</label>
                                <input type="number" placeholder="Altura">
                                
                                
                                <button class="waves-effect waves-light btn-small">Salvar<i class="material-icons left">save</i></button>
                            </form>
                        </div>

                        <div class="col-md center">
                            <h4>Histórico</h4>
                            <div id="container">
                                <div  >
                                    <div class="card-style" v-for="item of resultadosConsultas" :key="item.id" >
                                            <div v-for="procedimento of item.procedimentos" :key="procedimento.id">
                                            <h4> {{procedimento.tipoProcedimento.descricao}}</h4>
                                                <p>Médico: <br></p>
                                                <table >
                                                    <thead>
                                                        <tr>
                                                            <th>Descrição -</th>
                                                            <th>Resultado -</th>
                                                            <th>Resultado Referência</th>
                                                        </tr>
                                                    </thead>
                                                    <tbody>
                                                        <tr>
                                                            <td style="text-align:center;" >{{procedimento.exame.tipoExame.descricao}}</td>
                                                            <td style="text-align:center;" >{{procedimento.exame.resultado}} </td>
                                                            <td style="text-align:center;" >{{procedimento.exame.tipoExame.resultadoReferencia}}</td>
                                                        </tr>
                                                    </tbody>
                                                </table>
                                                <p>Observações:{{procedimento.observacao}} <br></p>

                                            </div>            
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                 </div>
            </div>
        <Footer/>
    </div>
  </div>
</template>


<script>
  
    import Header from '../template/Header'
    import Footer from '../template/Footer'

    import paciente from '../../../services/paciente'
    export default { 
        components: {
            Header,
            Footer,
            
        },
        mounted(){
            this.buscarPacientePeloCPF ();
        },

        data () {
            return {
                textError: '',
                cpfUsuario: 90790162091,
                resultadosPessoais: {},
                resultadosConsultas: [],
                idade: 20
            }
            
    },
        methods: {
        buscarPacientePeloCPF () {
            paciente.getByCpf(this.cpfUsuario)
                .then((res) => {
                    console.log('resultado da API => ', res.data.consultas)
                    this.resultadosPessoais = res.data
                    this.resultadosConsultas = res.data.consultas
                })
                .catch((err) => {
                    console.error('erro ao buscar na API =>', err)
                })
            },

        },
        toPage (route) {
        this.$router.push(route)
        }
  }
</script>


<style>
    body {
        background: #A1FFCE;  /* fallback for old browsers */
        background: -webkit-linear-gradient(to right, #FAFFD1, #A1FFCE);  /* Chrome 10-25, Safari 5.1-6 */
        background: linear-gradient(to right, #FAFFD1, #A1FFCE); /* W3C, IE 10+/ Edge, Firefox 16+, Chrome 26+, Opera 12+, Safari 7+ */
        display: flex;
        flex-direction: column;
    }

    #container {
        display: flex;
        flex-direction: row;
        flex-wrap: wrap;
        margin: auto;
        background:whitesmoke;
        border-radius: 20px;
        padding: 10px;
    }

    .card-style  {
        width: 100%;
        height: 200px;
        margin: 8px;
        background:rgb(230, 230, 230);
        border-radius: 10px;
        font-family: monospace;
        overflow-y: scroll;
        text-align: justify;
        padding: 10px;
    }
    .blackColor {
        color: black;
    }


</style>