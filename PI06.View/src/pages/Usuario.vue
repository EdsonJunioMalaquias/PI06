<template>
  <div class="content">
    <div class="md-layout">
      <div class="md-layout-item md-medium-size-100 md-xsmall-size-100 md-size-100">
        <md-card>
          <md-card-header data-background-color="green">
            <h4 class="title">Medicos</h4>
            <p class="category">Medicos Ativos</p>
          </md-card-header>
          <md-card-content>
            <md-card-actions>
              <md-button class="md-raised md-success">Novo</md-button>
              <md-button class="md-raised md-success">Editar</md-button>
            </md-card-actions>
          </md-card-content>
        </md-card>
      </div>
      <div class="md-layout-item md-medium-size-100 md-xsmall-size-100 md-size-100">
        <md-card>
          <md-card-header data-background-color="green">
            <h4 class="title">Enfermeiros</h4>
            <p class="category">Enfermeiros Ativos</p>
          </md-card-header>
          <md-card-content>
            <md-card-actions>
              <md-button class="md-raised md-success">Novo</md-button>
              <md-button class="md-raised md-success">Editar</md-button>
            </md-card-actions>
          </md-card-content>
        </md-card>
      </div>
      <div class="md-layout-item md-medium-size-100 md-xsmall-size-100 md-size-100">
        <md-card>
          <md-card-header data-background-color="green">
            <h4 class="title">Recepcionista</h4>
            <p class="category">Recepcionistas Ativos</p>
          </md-card-header>
          <md-card-content>
            <simple-table table-header-color="green"></simple-table>
            <md-card-actions>
              <md-button class="md-raised md-success">Novo</md-button>
              <md-button class="md-raised md-success">Editar</md-button>
            </md-card-actions>
          </md-card-content>
        </md-card>
      </div>
    </div>
  </div>
</template>

<script>
import { MedicoTable, EnfermeiroTable, SimpleTable } from "@/components";

export default {
  components: {
    MedicoTable,
    EnfermeiroTable,
    SimpleTable
  }
};
</script>
