<template>
  <div>
    <div v-for="fila of filteredList" :key="fila.id">
      <md-table v-model="fila.atendimentos" :table-header-color="tableHeaderColor">
        <md-table-row slot="md-table-row" slot-scope="{ item }">
          <md-table-cell md-label="ID">{{item.id }}</md-table-cell>
          <md-table-cell md-label="Nome">{{item.paciente.pessoa.nome }}</md-table-cell>
          <md-table-cell md-label="Medico">{{item.medico.pessoa.nome }}</md-table-cell>
          <md-table-cell
            md-label="Data de Chegada"
          >{{recebeDateTimeERetornaSomenteODate(item.dataChegada)}}</md-table-cell>
          <md-table-cell
            md-label="Hora de Chegada"
          >{{recebeDateTimeERetornaSomenteOTime(item.dataChegada)}}</md-table-cell>
          <md-table-cell md-label="Grau de Emergencia">{{item.grauDeEmergencia }}</md-table-cell>
          <md-table-cell md-label="Status">{{item.statusDeAtendimento }}</md-table-cell>
        </md-table-row>
      </md-table>
    </div>
  </div>
</template>

<script>
import fila from "../../../services/fila.js";
import moment from "moment";
export default {
  name: "ordered-table",
  props: {
    tableHeaderColor: {
      type: String,
      default: ""
    }
  },
  computed: {
    filteredList() {
      let result = this.users
      if (!this.filterValue){
        return result
      }
      const filter = event => 
        event.atendimentos.some(atendimento => atendimento.statusDeAtendimento.toString().toLowerCase().includes(this.filterValue.toString().toLowerCase()))
      
      return result.filter(filter)
    }
  },
  data() {
    return {
      users: [],
      filterValue: "",
      dateTime: ""
    };
  },
  mounted() {
    this.buscarAtendimentosFila();
    this.recebeDateTimeERetornaSomenteODate();
  },
  methods: {
    buscarAtendimentosFila() {
      fila.getAll().then(res => {
        this.users = res.data;
      });
    },
    recebeDateTimeERetornaSomenteODate(dateTime) {
      return moment(dateTime).format("YYYY-MM-DD");
    },
    recebeDateTimeERetornaSomenteOTime(dateTime) {
      return moment(dateTime).format("HH:mm:ss");
    }
  }
};
</script>
