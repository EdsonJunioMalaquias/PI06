<template>
  <div id="app">
    <div class="container">
      <md-card>

        <md-card-header data-background-color="green">
          <h4 class="title">Relatório</h4>
          <p class="category">Relatorio dos Médicos</p>
        </md-card-header>

        <md-card-content >

          <md-card-media>
           <iframe 
            src= "https://app.powerbi.com/view?r=eyJrIjoiZmI0YTZlZjItMTU3MC00NGE0LThmZDctOWFjZjM0YzBjNmQ1IiwidCI6IjNiYjVlMmZkLWRmMTYtNDVhOC1iMGE3LTcwOTY3ZjNjNmQ4MiJ9"
            >
            </iframe>
          </md-card-media>

          
          
        </md-card-content>

      </md-card>       
    </div>

    
    
  </div>
</template>
<style>
.md-list-item-text{
  position:unset !important;
}
.md-card-media{
  width: 100% !important;
  height: 100% !important;
}
iframe{
  height: 425px !important;
  width: 1000px !important;
}
.explorationContainer .exploreCanvas .canvasFlexBox .displayAreaContainer {
    width: 100%;
    height: 100%;
    position: relative;
}
.explorationContainer .exploreCanvas .canvasFlexBox .displayAreaContainer {
    width: 100%;
    height: 100%;
    position: relative;
}
.explorationContainer .exploreCanvas .canvasFlexBox .displayAreaContainer .displayArea {
    width: 100%;
    height: 1000%;
    position: relative;
    box-sizing: border-box;
    overflow: hidden;
}
.explorationContainer .exploreCanvas .backgroundContainer.outspaceContainer {
    height: 1000px;
    width: 100%;
}

</style>       

<script>
export default {
  data() {
    return {
      loaded: false,
      iframe: {
       
      }
    }
  },
  mounted() {
   
  }
}
</script>

                   
