<script>
    import Header from '../template/Header'
    import Footer from '../template/Footer'
    import Card from './card'

    export default {
      components: {
        Header,
        Footer,
        Card
      }
    }
</script>
<template>
  <div>
    <div class="form">
        <Header title="Consulta" hideToggle="false" hideUserDropdown="false" />
            <div>
                <div class="container">
                
                    <div class="row">
                        <div class="col-md">
                            <form>
                                <h4>Dados Pessoais</h4>
                                <label>Nome</label>
                                <input type="text" readonly placeholder="Nome">
                                <label>Idade</label>
                                <input type="number" readonly placeholder="QTD">
                                <label>Valor</label>
                                <input type="text" placeholder="Valor">
                                <button class="waves-effect waves-light btn-small">Salvar<i class="material-icons left">save</i></button>
                            </form>
                        </div>

                        <div class="col-md center">
                            <h4>Histórico</h4>
                            <div id="container">
                                <Card title="Shea" content="Lorem Ipsum é simplesmente uma simulação de texto da indústria tipográfica e de impressos, e ."></card>
                                <Card title="Bobby" content="This is the content!"></card>
                                <Card title="Ashley" content="This is the content!"></card>
                                <Card title="Katie" content="This is the content!"></card>
                            </div>
                            <table>
                                <thead>
                                    <tr>
                                        <th>NOME</th>
                                        <th>QTD</th>
                                        <th>VALOR</th>
                                        <th>OPÇÕES</th>
                                    </tr>
                                </thead>
                                <tbody>
                                    <tr>
                                        <td>Arduino</td>
                                        <td>100</td>
                                        <td>50.00</td>
                                        <td>
                                        <button class="waves-effect btn-small blue darken-1"><i class="material-icons">create</i></button>
                                        <button class="waves-effect btn-small red darken-1"><i class="material-icons">delete_sweep</i></button>
                                        </td>
                                    </tr>
                                </tbody>
                            </table>
                        </div>
                    </div>
                 </div>
            </div>
        <Footer/>
    </div>
  </div>
</template>

