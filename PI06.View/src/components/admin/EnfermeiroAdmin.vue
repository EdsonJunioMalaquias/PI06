    <template>
    <div class="enfermeiro-admin">
        <h1>{{title}}</h1>
        <input type="text" placeholder="Nome do Enfermeiro" v-model="nome" v-on:keyup.enter="addEnfermeiro()" />
        <b-button variant="outline-primary" class="btn btnInput" @click="buscar(enfermeiro)">Buscar</b-button>

        <table>
        <thead>
            <th>Codigo</th>
            <th>Nome</th>
            <th>email</th>
            <th>rg</th>
            <th>codigoCPF</th>
            <th>cre</th>
            <th>Opcoes</th>
        </thead>
        <tbody v-if="enfermeiros.length">
            <tr v-for="(enfermeiro, index) in enfermeiros" :key="index">
            <td>{{enfermeiro.id}}</td>
            <td>{{enfermeiro.nome}}{{enfermeiro.sobrenome}}</td>
            <td>{{enfermeiro.enderecoEmail}}</td>
            <td>{{enfermeiro.rg}}</td>
            <td>{{enfermeiro.codigoCpf}}</td>
            <td>{{enfermeiro.sus}}</td>
            <td>
                <b-button variant="outline-primary" class="btn" @click="remover(enfermeiro)">Remover</b-button>
            </td>
            </tr>
        </tbody>
        <tfoot v-if="!enfermeiros.length">Nehum Enfermeiro Encontrado</tfoot>
        </table>
    </div>
    </template>

<script>
export default {
  data() {
    return {
      title: "Enfermeiro",
      nome: "",
      sobrenome: "",
      enfermeiros: []
    };
  },
  created() {
    this.$http
      .get("http://localhost:3000/enfermeiros")
      .then(res => res.json().then(enfermeiros => (this.enfermeiros = enfermeiros)));
  },
  props: {},
  methods: {
    addEnfermeiro() {
      let _enfermeiro = {
        nome: this.nome,
        sobrenome: "",
        enderecoEmail:this.enderecoEmail,
        rg: this.rg,
        condigoCpf:this.codigoCpf,
        

      };

      this.$http
        .post("http://localhost:3000/enfermeiros", _enfermeiro)
        .then(res => res.json())
        .then(enfermeiroRetornado => {
          this.enfermeiros.push(enfermeiroRetornado);
          this.nome = "";
        });
    },
    remover(enfermeiro) {
      this.$http
        .delete(`http://localhost:3000/enfermeiros/${enfermeiro.id}`)
        .then(() => {
          let indice = this.enfermeiros.indexOf(enfermeiro);
          this.enfermeiros.splice(indice, 1);
        });
    }
  }
};
</script>
<style >
input {
  border: 0ch;
  width: 80%;
  height: 20px;
  border: 1;
  padding: 20px;
}
.btnInput {
  width: 20%;
  height: 20px;
  padding: 20px;
  text-align: center;
}

</style>