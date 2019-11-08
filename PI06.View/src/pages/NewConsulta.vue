<template>
  <div>
	<div class="form">
			<div>
				<div class="md-layout">
				
						<div  class="md-layout-item md-small-size-50 md-size-50">
							<form>
								<h4>Dados Pessoais</h4>
								<md-field>
									<label for="Nome">Nome</label>
									<md-input type="text" id="Nome"  readonly :value="resultadosPessoais.nome"></md-input>
								</md-field>
								<md-field>
									<label for="sus">SUS:</label>
									<md-input type="number" id="sus"   readonly :value="resultadosPessoais.sus"></md-input>
								</md-field>
								<md-field>
									<label>Idade</label>
									<md-input type="number" readonly :value="idade">></md-input>
								</md-field>
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

								<md-field>
									<label>Observações</label>
									<md-textarea v-model="observacao" required maxlength="100"></md-textarea>
									<span class="md-error">Preencha a Observações!</span>
								</md-field>
					

								<md-field>
									<label >Exames</label>
									<md-select v-model="idTipoExame">
										<md-option v-for="item in this.ListaExames" :key="item.id" :value="item.id"  > {{item.descricao}}</md-option>
									</md-select>
								</md-field>
								
								<md-field>
									<label>Resultado</label>
									<md-input type="text" placeholder="Resultado" v-model="resultado" required></md-input>
									<span class="md-error">Campo Obrigatorio!</span>
								</md-field>
							
								<md-button v-on:click.prevent="AdicionarExame()" class="md-raised md-primary" >Adcionar Exame</md-button>
								 							
								<label>Exames Incluidos</label>
								<ul>
									<li v-for="item in exames" :key="item.id">
									   {{item.id}} - {{item.resultado}} -<span @click.prevent="RemoverExame(item.id)" > Remover</span> - <span @click.prevent="EditarExame(item.id,item.resultado)" >Editar</span> 
									</li>
									
					  
								</ul>
								
								<md-button @click.prevent="CadastrarConsulta()" class="md-raised md-primary">Cadastrar Consulta</md-button>
								
								<md-snackbar md-position="center" :md-duration="duracao" :md-active.sync="showSnackbar" md-persistent>
									<span>{{error}}</span>
									<md-button class="md-primary" @click="showSnackbar = false">Fechar</md-button>
								</md-snackbar>
								
							</form>
						</div>
						<div class="md-size-50">
							<md-card md-with-hover>
								<md-ripple>
									<md-card-header>
										<div class="md-title">Histórico</div>
									</md-card-header>

									<md-card-content>
										<div>
											<div class="card-style" v-for="item of resultadosConsultas" :key="item.id" >
												<div v-for="procedimento of item.procedimentos" :key="procedimento.id">
													<div class="md-title">{{procedimento.tipoProcedimento.descricao}}</div>
													<h4> {{procedimento.tipoProcedimento.descricao}}</h4>
													<p>Médico: <br></p>
													<md-table >
															<md-table-row>
																<md-table-head>Descrição</md-table-head>
																<md-table-head>Resultado</md-table-head>
																	<md-table-head>Resultado Referência</md-table-head>
																</md-table-row>
																<md-table-row>
																	<md-table-cell>{{procedimento.exame.resultado}} </md-table-cell>
																	<md-table-cell>{{procedimento.exame.tipoExame.resultadoReferencia}}</md-table-cell>
																</md-table-row>
														</md-table>
														<p>Observações:{{procedimento.observacao}} <br></p>
													</div>            
												</div>
											</div>
										</md-card-content>

									<md-card-actions>
										<md-button>Action</md-button>
										<md-button>Action</md-button>
									</md-card-actions>
								</md-ripple>
							</md-card>
						

						</div>
					
				 </div>
			</div>
	</div>
  </div>
</template>

<script>

/* eslint-disable */
	import paciente from '../../services/paciente'
	import tipoExame from '../../services/tipoExame'
	import consulta from '../../services/consulta'
	import procedimento from '../../services/procedimento'
	import exame from '../../services/exame'
	const toLower = text => {
		return text.toString().toLowerCase()
	}

	const searchByName = (items, term) => {
		if (term) {
			return items.filter(item => toLower(item.name).includes(toLower(term)))
		}

		return items
	}
	export default { 
		mounted(){
			this.ListarTipoExame();
			this.buscarPacientePeloCPF();
			this.dateNow = new Date();
		},
  
		computed:(
			{
				imc:function(){
				   return(this.peso== 0 || this.altura== 0) ?0: parseFloat(this.peso/(Math.pow(this.altura,2))).toFixed(2);
				},
				
			}),

		data () {
			return {
				showSnackbar: false,
				error: "Erro Inesperado!",
				duracao: 4000,

				medicoiD:1,
				cpfUsuario: 90790162091,
				idTipoProcedimento : 1,
				
				resultadosPessoais: {},
				resultadosConsultas: [],
				ListaExames:[],

				idTipoExame:0,
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
						
					}).catch((err)=> {
						this.error = err.message;
						this.showSnackbar = true;
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

	textarea{
		height: 10rem;
		width: 100%;
	}

</style>
<style lang="scss" scoped>
	.md-card {
		width: 100%;
		margin: 4px;
		display: inline-block;
		vertical-align: top;
	}
	.md-field {
		max-width: 300px;
	}
</style>