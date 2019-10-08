<template>
  <div class="hello">
    <div id="app">
      <div class="caixa">
        <b-img src="https://logodownload.org/wp-content/uploads/2017/02/sus-logo.png" fluid alt="Responsive image"></b-img>
        <div id="campo">
           <b-form @submit="onSubmit" @reset="onReset" v-if="show">
              <b-form-group
                id="input-group-1"
                label-for="input-1"
              >
              <b-form-input
                  id="input-1"
                  v-model="form.email"
                  type="email"
                  required
                  placeholder="Email"
                ></b-form-input>
              </b-form-group>

              <b-form-group id="input-group-2" label-for="text-password">
                <b-form-input
                  id="text-password"
                  type="password"
                  v-model="form.senha"
                  required
                  placeholder="Senha"
                ></b-form-input>
              </b-form-group>
            </b-form>
          <b-button type="entrar" variant="primary">Entrar</b-button>
          <div>
            <b-link href="#" disabled>Esqueceu sua senha</b-link>
          </div>
        </div>     
      </div>
    </div>
  </div>
</template>

<script>
export default {
    data() {
      return {
        form: {
          email: '',
          senha: '',
        },
        show: true
      }
    },
    methods: {
      onSubmit(evt) {
        evt.preventDefault()
        alert(JSON.stringify(this.form))
      },
      onReset(evt) {
        evt.preventDefault()
        // Reset our form values
        this.form.email = ''
        this.form.senha = ''
        // Trick to reset/clear native browser form validation state
        this.show = false
        this.$nextTick(() => {
          this.show = true
        })
      }
    }
  }
  
</script>


<style scoped>

.caixa{
  background-color:#ffffff;
  border-radius: 15px;
  box-shadow:3px 2px 10px 10px #0000002b;
  margin-right: 32%;
  margin-left: 32%;
  margin-top: 6%;
  height: 425px;
}

.btn-primary{
  width: 90%!important;
  margin-top: 5%;
  box-shadow:3px 2px 10px 2px #0000002b;
  margin-bottom: 3%;
}

.form-control{
  
  margin-left: 5%;
  width: 90%;
  display: block;
}
#campo{
  padding-top: 8%;
}
h1{
  padding-top: 15%;
}

a{
  color: #0056b3;
  margin-left:55%;
}

.img-fluid{
  margin-top: 5%;
  max-width: 60%;
}

</style>
