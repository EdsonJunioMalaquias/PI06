
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
								<input type="text" readonly :value="resultadosPessoais.nome">

								<label>SUS:</label>
								<input type="number" readonly :value="resultadosPessoais.sus">

								<label>Idade:</label>
								<input type="number" readonly :value="idade">
								
								<hr>
						<!--        <h5>Triagem</h5>
								<br>

								<label>Peso em Kg:</label>
								<input type="number" placeholder="Peso" v-model="peso">

								<label>Altura em metros:</label>
								<input type="number" placeholder="Altura" v-model="altura">

								<label>Preção:</label>
								<input type="number" placeholder="Preção" v-model="precao">
								
								<label>Batimentos Cardíacos:</label>
								<input type="number" placeholder="Batimentos Cardíacos" v-model="batcardia">

								<label>IMC</label>
								<input type="number" placeholder="IMC" v-model="imc">
								
								<br><br>
								<label for="">Protocolo de Manchester:</label>
								<select v-model="protManchester">
									<option value="0" > Selecione</option>
									<option value="1" style="color:red"> Emergência</option>
									<option value="2" style="color:orange"> Muito Urgente</option>
									<option value="3" style="color:#737326"> Urgente</option>
									<option value="4" style="color:#12b312"> Pouco Urgente</option>
									<option value="5" style="color:blue"> Não Urgente</option>   
								</select>-!-->
								
								<h5>Dados Nova Consulta</h5>

								<label>Observações:</label>
									<p>
										<textarea v-model="observacao" rows="5" cols="5"></textarea>
									</p>
								

								
								<label for="">Exame</label>
								<select v-model="idTipoExame">
									<option value="-1">Selecione</option>
									<option v-for="item in this.ListaExames" :key="item.id" :value="item.id"  > {{item.descricao}}</option>

								</select>
								
								<br>
								<br>
								<input type="text" placeholder="Resultado" v-model="resultado">
								<br>
								<br>
								<button v-on:click.prevent="AdicionarExame()" class="waves-effect waves-light btn-small">+<i class="material-icons left">more</i></button>
								<br>
								<br>
								
								<label>Exames Incluidos</label>
								<ul>
									<li v-for="item in exames" :key="item.id">
									   {{item.id}} - {{item.resultado}} -<span @click.prevent="RemoverExame(item.id)" > Remover</span> - <span @click.prevent="EditarExame(item.id,item.resultado)" >Editar</span> 
									</li>
									
					  
								</ul>
								
								 <button @click.prevent="CadastrarConsulta()" class="waves-effect waves-light btn-small">Salvar<i class="material-icons left">save</i></button>
							   
								
							</form>
						</div>

						<div class="col-md center">
							<h4>Histórico</h4>
							<div id="container">
								<div  >
									<div class="card-style" v-for="item of resultadosConsultas" :key="item.id" >
											<div v-for="procedimento of item.procedimentos" :key="procedimento.id">
											<h4> {{procedimento.tipoProcedimento.descricao}}</h4>
												<p>Médico: <br></p>
												<table >
													<thead>
														<tr>
															<th>Descrição -</th>
															<th>Resultado -</th>
															<th>Resultado Referência</th>
														</tr>
													</thead>
													<tbody>
														<tr>
															<td style="text-align:center;" >{{procedimento.exame.tipoExame.descricao}}</td>
															<td style="text-align:center;" >{{procedimento.exame.resultado}} </td>
															<td style="text-align:center;" >{{procedimento.exame.tipoExame.resultadoReferencia}}</td>
														</tr>
													</tbody>
												</table>
												<p>Observações:{{procedimento.observacao}} <br></p>

											</div>            
									</div>
								</div>
							</div>
						</div>
					</div>
				 </div>
			</div>
		<Footer/>
	</div>
  </div>
</template>

<script>
  
	import Header from '../template/Header'
	import Footer from '../template/Footer'
	import paciente from '../../../services/paciente'
	import tipoExame from '../../../services/tipoExame'
	import consulta from '../../../services/consulta'
	import procedimento from '../../../services/procedimento'
	import exame from '../../../services/exame'

	export default { 
		components: {
			Header,
			Footer,
			
		},
		mounted(){
			this.ListarTipoExame();
			this.buscarPacientePeloCPF();
			this.dateNow = new Date();
		},
  
		computed:(
			{
				imc:function(){
				   return(this.peso== 0 || this.altura== 0) ?0: parseFloat(this.peso/(Math.pow(this.altura,2))).toFixed(2);
				}
			}),

		data () {
			return {
				medicoiD:1,
				cpfUsuario: 90790162091,
				idTipoProcedimento : 1,
				
				resultadosPessoais: {},
				resultadosConsultas: [],
				ListaExames:[],

				idTipoExame:-1,
				resultado:"",
				dateNow: "",
				idade: 0,
				
				/*peso: 0,
				altura:0,
				protManchester: 0,
				precao:0,
				batcardia:0,*/
				textarea:"",
			  
				exames:[],

				observacao:"",
			}
			
	},
		methods: {
			AdicionarExame(){
				this.exames.push({
				   resultado:this.resultado,
					id:this.idTipoExame
				})
			},
			RemoverExame(id){
				this.exames.splice(this.exames.indexOf(id), 1);
			},
			EditarExame(id, resultado){
				this.resultado = resultado;
				this.idTipoExame = id;
				
			},

			buscarPacientePeloCPF () {
				paciente.getByCpf(this.cpfUsuario)
					.then((res) => {
						this.resultadosPessoais = res.data.pessoa
						this.resultadosConsultas = res.data.consultas
						this.calculaIdade();
					})
				},
			calculaIdade(){
				var dataNasc = new Date(this.resultadosPessoais.dataNascimento);
				var currentDate = new Date();
				var currentYear = currentDate.getFullYear();
				var birthdayThisYear = new Date(currentYear, dataNasc.getMonth(), dataNasc.getDate());
				this.idade = currentYear - dataNasc.getFullYear();
				if(birthdayThisYear > currentDate) {
					this.idade--;
				}
			
			},
			ListarTipoExame(){
				tipoExame.get()
					.then((res) => {
						this.ListaExames = res.data;
					})
			},
			CadastrarConsulta(){
				var obj = {
					idPaciente:this.resultadosPessoais.id,
					idFuncionarioMedico: this.medicoiD,
					dataInicio: this.dateNow,
					dataTermino: new Date()
				}
				
			consulta.post(obj)
			.then((res) => {
					 this.cadastrarProcedimento(res.data.id);
				});
			},
			cadastrarProcedimento(idConsulta){
				var obj = {
					observacao: this.observacao,
					idConsulta: idConsulta,
					idTipoProcedimento: this.idTipoProcedimento
				}
				procedimento.post(obj)
				.then((res) => {
					 this.cadastrarExame(res.data.id);
				});
				
			},
		
			cadastrarExame(idProcedimentoExame){
				
				this.exames.forEach(element => {
					var obj = {
						resultado: element.resultado,
						idTipoExame: element.id,
						iD:idProcedimentoExame
				   
					}
					exame.post(obj);
				
				});
				this.buscarPacientePeloCPF();
			
			},
			toPage (route) {
			this.$router.push(route)
			}
	}
}
</script>


<style>
	body {
		background: #A1FFCE;  /* fallback for old browsers */
		background: -webkit-linear-gradient(to right, #FAFFD1, #A1FFCE);  /* Chrome 10-25, Safari 5.1-6 */
		background: linear-gradient(to right, #FAFFD1, #A1FFCE); /* W3C, IE 10+/ Edge, Firefox 16+, Chrome 26+, Opera 12+, Safari 7+ */
		display: flex;
		flex-direction: column;
	}

	#container {
		display: flex;
		flex-direction: row;
		flex-wrap: wrap;
		margin: auto;
		background:whitesmoke;
		border-radius: 20px;
		padding: 10px;
	}

	.card-style  {
		width: 100%;
		height: 200px;
		margin: 8px;
		background:rgb(230, 230, 230);
		border-radius: 10px;
		font-family: monospace;
		overflow-y: scroll;
		text-align: justify;
		padding: 10px;
	}
	.blackColor {
		color: black;
	}
	label {
		color: black !important;
	}
	input[readonly="readonly"]{
		color:rgb(90, 90, 90) !important;
	}
	hr{
		border: 1em;
		color: black;
	}
	select{
		display: inline;
	}
	textarea{
		height: 10rem;
	}

</style>