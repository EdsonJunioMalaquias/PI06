<template>
  <div class="recepcionista-admin">
    <h1>{{title}}</h1>
    <input type="text" placeholder="Nome do recepcionista" v-model="nome" v-on:keyup.enter="addrecepcionista()" />
    <b-button variant="outline-primary" class="btn btnInput" @click="buscar(recepcionista)">Buscar</b-button>

    <table>
      <thead>
        <th>Codigo</th>
        <th>Nome</th>
        <th>email</th>
        <th>rg</th>
        <th>codigoCPF</th>
        <th>Data Contrataçao </th>
        <th>Opcoes</th>
      </thead>
      <tbody v-if="recepcionistas.length">
        <tr v-for="(recepcionista, index) in recepcionistas" :key="index">
          <td>{{recepcionista.id}}</td>
          <td>{{recepcionista.nome}}{{recepcionista.sobrenome}}</td>
          <td>{{recepcionista.enderecoEmail}}</td>
          <td>{{recepcionista.rg}}</td>
          <td>{{recepcionista.codigoCpf}}</td>
          <td>{{recepcionista.dataContratacao}}</td>
          <td>
            <b-button variant="outline-primary" class="btn" @click="remover(recepcionista)">Remover</b-button>
          </td>
        </tr>
      </tbody>
      <tfoot v-if="!recepcionistas.length">Nehum recepcionista Encontrado</tfoot>
    </table>
  </div>
</template>

<script>
export default {
  data() {
    return {
      title: "recepcionista",
      nome: "",
      sobrenome: "",
      recepcionistas: []
    };
  },
  created() {
    this.$http
      .get("http://localhost:3000/recepcionistas")
      .then(res => res.json().then(recepcionistas => (this.recepcionistas = recepcionistas)));
  },
  props: {},
  methods: {
    addrecepcionista() {
      let _recepcionista = {
        nome: this.nome,
        sobrenome: "",
        enderecoEmail:this.enderecoEmail,
        rg: this.rg,
        condigoCpf:this.codigoCpf,
        

      };

      this.$http
        .post("http://localhost:3000/recepcionistas", _recepcionista)
        .then(res => res.json())
        .then(recepcionistaRetornado => {
          this.recepcionistas.push(recepcionistaRetornado);
          this.nome = "";
        });
    },
    remover(recepcionista) {
      this.$http
        .delete(`http://localhost:3000/recepcionistas/${recepcionista.id}`)
        .then(() => {
          let indice = this.recepcionistas.indexOf(recepcionista);
          this.recepcionistas.splice(indice, 1);
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
table {
  display: inline-block;
}
</style>