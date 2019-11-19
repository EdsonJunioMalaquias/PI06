<template>
  <form>
    <md-card>
      <md-card-header :data-background-color="dataBackgroundColor">
        <h4 class="title">Cadastro de Pessoas</h4>
        <p class="category">Prencha os Campos a baixo</p>
      </md-card-header>

      <md-card-content>
        
        <div class="md-layout">
          <div class="md-layout-item md-small-size-100 md-size-100">
            <md-field>
              <h4 class="title">Dados Pessoais</h4>
              
            </md-field>
          </div>
          <div class="md-layout-item md-small-size-100 md-size-50">
            <md-field>
              <label>Nome</label>
              <md-input v-model="nome" type="text"></md-input>
            </md-field>
          </div>
          <div class="md-layout-item md-small-size-50 md-size-50">
            <md-field>
                <md-datepicker v-model="date" md-debounce="100" />
                
            </md-field>
          </div>
          <div class="md-layout-item md-small-size-100 md-size-50">
            <md-field>
              <label>rg</label>
              <md-input v-model="idade" type="text"></md-input>
            </md-field>
          </div>
           <div class="md-layout-item md-small-size-100 md-size-50">
            <md-field>
              <label>Cpf</label>
              <md-input v-model="idade" type="text"></md-input>
            </md-field>
          </div>
           <div class="md-layout-item md-small-size-100 md-size-100">
            <md-field>
              <label>Endereco de email</label>
              <md-input v-model="idade" type="email"></md-input>
            </md-field>
          </div>
           <div class="md-layout-item md-small-size-100 md-size-50">
            <md-field>
              <label>logradouro</label>
              <md-input v-model="idade" type="text"></md-input>
            </md-field>
          </div>
           <div class="md-layout-item md-small-size-100 md-size-50">
            <md-field>
              <label>Complemento</label>
              <md-input v-model="idade" type="text"></md-input>
            </md-field>
          </div>
          <div class="md-layout-item md-small-size-100 md-size-50">
            <md-field>
              <label>Numero</label>
              <md-input v-model="idade" type="text"></md-input>
            </md-field>
          </div>
          <div class="md-layout-item md-small-size-100 md-size-50">
            <md-autocomplete v-model="selectCidade" :md-options="cidades">
            <label>Cidade</label>
            </md-autocomplete>
          </div>
          <div class="md-layout-item md-small-size-100 md-size-50">
            <md-autocomplete v-model="selectCidade" :md-options="uf">
            <label>Uniodade Federativa</label>
            </md-autocomplete>
          </div>
          <div class="md-layout-item md-small-size-100 md-size-50">
            <md-field>
                
              <label>Numero de Telefone</label>
              <md-input v-model="idade" type="text"></md-input>
            </md-field>
          </div>
          <div class="md-layout-item md-small-size-100 md-size-50">
            <md-field>
              <label>Cep</label>
              <md-input v-model="idade" type="number"></md-input>
            </md-field>
          </div>
          <div class="md-layout-item md-small-size-100 md-size-50">
            <md-autocomplete v-model="selectCargo" :md-options="cargo">
            <label>Cargo</label>
            </md-autocomplete>
          </div>
          <div class="md-layout-item md-size-100 text-right">
            <md-button class="md-raised md-success">Nova Cadastro</md-button>
          </div>
        </div>
      </md-card-content>
    </md-card>
  </form>
</template>
<script>
 /* import paciente from '../../../services/paciente' */
export default {
  name: "cadastro-pessoa-form",
  props: {
    dataBackgroundColor: {
      type: String,
      default: ""
    }
  },
  data: () => ({
      selectedCidade: null,
      selectedUF: null,
      cidades: [
        'Patos de Minas',
        'Guimarania',
        'Belo Horizonte',
        'Presidente Olegario',
        'Carmo do Paranaiba'
        
      ],
      uf: [
        'MG',
        'SP',
        'RJ'
        
      ],
      cargo:[
          'Medico',
          'Recepcionista',
          'Enfermeiro',
          'Paciente' 
      ]
    })
 
};
</script>
<style></style>
