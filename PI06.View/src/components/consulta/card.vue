<template>
    <div class="card-style">
        <button class="waves-effect btn-small blue darken-1"><i class="material-icons">create</i></button>
        <h1 class="title blackColor">{{ title }}</h1>
        <p>{{ content }}</p>
         
    </div>
</template>
<script>
  import paciente from '../../../services/paciente'
    export default { 
        name: 'Card',
        props: {
            title: String, 
            content: String,
            medico: String,
        },
        data () {
            return {
                text: '',
                cpfUsuario: null,
                resultadosPessoais: [],
                resultadosConsultas: []
            }
            
    },
        methods: {
        buscarPacientePeloCPF () {
            paciente.getByCpf(this.cpfUsuario)
            .then((res) => {
                console.log('resultado da API => ', res)
                this.resultadosPessoais = res.data
            })
            .catch((err) => {
                console.error('erro ao buscar na API =>', err)
            })
        },
            buscarConsultas () {
            paciente.getByCpf(this.resultadosPessoais.data.paciente.id)
            .then((res) => {
                console.log('resultado da API => ', res)
                this.resultadosConsultas = res.data
            })
            .catch((err) => {
                console.error('erro ao buscar na API =>', err)
            })
        }
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