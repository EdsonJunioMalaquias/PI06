<template>
  <div>
    <div v-for="fila of users" :key="fila.id">
      <md-table v-model="fila.atendimentos" :table-header-color="tableHeaderColor">
        <md-table-row slot="md-table-row" slot-scope="{ item }">
          <md-table-cell md-label="ID">{{item.id }}</md-table-cell>
          <md-table-cell md-label="Nome">{{item.paciente.pessoa.nome }}</md-table-cell>
          <md-table-cell md-label="Medico">{{item.medico.pessoa.nome }}</md-table-cell>
          <md-table-cell md-label="Data de Chegada">{{item.dataChegada }}</md-table-cell>
          <md-table-cell md-label="Hora de Chegada">{{item.Hora_Chegada }}</md-table-cell>
          <md-table-cell md-label="Grau de Emergencia">{{item.grauDeEmergencia }}</md-table-cell>
          <md-table-cell md-label="Status">{{item.statusDeAtendimento }}</md-table-cell>
        </md-table-row>
      </md-table>
    </div>
  </div>
</template>

<script>
import fila from "../../../services/fila.js";
export default {
  name: "ordered-table",
  props: {
    tableHeaderColor: {
      type: String,
      default: ""
    }
  },
  data() {
    return {
      selected: [],
      users: [],
      result: []
    };
  },
  mounted() {
    this.buscarAtendimentosFila();
  },
  methods: {
    buscarAtendimentosFila() {
      fila.getAll().then(res => {
        console.log(res.data);
        this.users = res.data;
      });
    }
  }
};
</script>
