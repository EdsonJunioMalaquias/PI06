<template>
  <div id="app">
    <div class="container">
      <md-card>
        <md-card-header data-background-color="green">
          <h4 class="title">Relatorio</h4>
          <p class="category">Relatorio dos Medicos</p>
        </md-card-header>

        <md-card-content>
          <md-field id="editor" ref="editor">
            <iframe
              v-if="loaded"
              :src="iframe.src"
              :style="iframe.style"
              :height="iframe.style.height"
              :width="iframe.style.width"
              frameborder="0"
            ></iframe>
          </md-field>
        </md-card-content>
      </md-card>
    </div>
  </div>
</template>

<script>
export default {
  data() {
    return {
      loaded: false,
      iframe: {
        src:
          "https://app.powerbi.com/view?r=eyJrIjoiZmI0YTZlZjItMTU3MC00NGE0LThmZDctOWFjZjM0YzBjNmQ1IiwidCI6IjNiYjVlMmZkLWRmMTYtNDVhOC1iMGE3LTcwOTY3ZjNjNmQ4MiJ9",
        style: null,
        wrapperStyle: null
      }
    };
  },
  mounted() {
    let editor = this.$refs.editor;
    this.iframe.style = {
      position: "absolute",
      width: window.innerWidth,
      height: window.innerHeight,
      top: -editor.offsetTop + "px",
      left: -editor.offsetLeft + "px"
    };
    this.iframe.wrapperStyle = {
      overflow: "hidden",
      height: editor.clientHeight + "px",
      width: editor.clientWidth + "px"
    };
    this.loaded = true;
  }
};
</script>

<style>
.md-list-item-text {
  position: unset !important;
}
</style>
