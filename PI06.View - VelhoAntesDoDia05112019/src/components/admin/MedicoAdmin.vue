<template>
  <div class="medico-admin">
    <h1>{{title}}</h1>
    <input type="text" placeholder="Nome do Medico" v-model="nome" v-on:keyup.enter="addMedico()" />
    <b-button variant="outline-primary" class="btnInput" @click="buscar(medico)">Buscar</b-button>

    <table>
      <thead>
        <th>Codigo</th>
        <th>Nome</th>
        <th>email</th>
        <th>rg</th>
        <th>codigoCPF</th>
        <th>CRM</th>
        <th>Opcoes</th>
      </thead>
      <tbody v-if="medicos.length">
        <tr v-for="(medico, index) in medicos" :key="index">
          <td>{{medico.id}}</td>
          <td>{{medico.nome}}{{medico.sobrenome}}</td>
          <td>{{medico.enderecoEmail}}</td>
          <td>{{medico.rg}}</td>
          <td>{{medico.codigoCpf}}</td>
          <td>{{medico.crm}}</td>
          <td>
            <b-button variant="outline-primary" class="btn" @click="remover(medico)">Remover</b-button>
          </td>
        </tr>
      </tbody>
      <tfoot v-if="!medicos.length">Nehum Medico Encontrado</tfoot>
    </table>
  </div>
</template>

<script>
export default {
  data() {
    return {
      title: "Medico",
      nome: "",
      sobrenome: "",
      medicos: []
    };
  },
  created() {
    this.$http
      .get("http://localhost:3000/medicos")
      .then(res => res.json().then(medicos => (this.medicos = medicos)));
  },
  props: {},
  methods: {
    addMedico() {
      let _medico = {
        nome: this.nome,
        sobrenome: "",
        enderecoEmail:this.enderecoEmail,
        rg: this.rg,
        condigoCpf:this.codigoCpf,
        

      };

      this.$http
        .post("http://localhost:3000/medicos", _medico)
        .then(res => res.json())
        .then(medicoRetornado => {
          this.medicos.push(medicoRetornado);
          this.nome = "";
        });
    },
    remover(medico) {
      this.$http
        .delete(`http://localhost:3000/medicos/${medico.id}`)
        .then(() => {
          let indice = this.medicos.indexOf(medico);
          this.medicos.splice(indice, 1);
        });
    }
  }
};
</script>
<style >
input {
  border: 0ch;
  width: 80%;
  height: 50px;;
  border: 1;
  padding: 20px;
}
.btnInput {
  width: 20%;
  height: 20px;
  padding: 20px;
  text-align: left;
}

</style>