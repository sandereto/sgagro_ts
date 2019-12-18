import React, { Component, Fragment } from 'react';
import { withRouter } from 'react-router-dom';
import Title from '../../../components/Title/title.component';
import Table from '../../../components/Table/table.component';
import tituloService from '../../../services/tituloService';
import situacaoService from '../../../services/situacaoService';
import DateHelper from 'utils/dateHelper';
import {NUMERO_ITENS_POR_PAGINA} from '../../../constants/index';
import { CardStyle } from './apontamento_colaborador.cadastro.style';
import { Field, ErrorMessage } from 'formik';
import Select from 'react-select'
import './apontamento_colaboradores.scss'

class ApontamentoColaboradorCadastro extends Component {
	state = {
		search: '',
		situacoes: [],
		data:{
			items: [],
            total : 0,
            pageCount: 0,
            page: 0,
            pageSize: 0
		},
		isOpenCadastrar: false,
	};

	columns = [
		{ id: 0, title: '', property: 'especieNome'},
		{ id: 1, title: 'Apontamento', property: 'apontamento' },
		{ id: 2, title: 'Espécie', property: 'especieNome' },
		{ id: 3, title: 'Número', property: 'nossoNumero' },
		{ id: 4, title: 'Vencimento', property: 'vencimento', template: (texto)=> DateHelper.formatStringDate(texto) },
		{ id: 5, title: 'Emissao', property: 'emisssao', template: (texto)=> DateHelper.formatStringDate(texto) },
		{ id: 6, title: 'Valor', property: 'valor' },
	];

	equipes = [
		{ id: 0, nome: 'equipe 1', membros: [
			{
				id: 1,
				nome:'Bruno'
			},
			{
				id: 2,
				nome:'Leite'
			},
			{
				id: 3,
				nome:'Rodrigo'
			}
		]},
		{ id: 1, nome: 'equipe 2', membros: [
			{
				id: 1,
				nome:'Carlos'
			},
			{
				id: 2,
				nome:'Hebert'
			},
			{
				id: 3,
				nome:'Lucas'
			}
		]},	
		{ id: 2, nome: 'equipe 3', membros: [
			{
				id: 1,
				nome:'Douglas'
			},
			{
				id: 2,
				nome:'Sergio'
			},
			{
				id: 3,
				nome:'Rogerio'
			}
		]},
		{ id: 3, nome: 'equipe 4', membros: [
			{
				id: 1,
				nome:'Atalanta'
			},
			{
				id: 2,
				nome:'Jucilene'
			},
			{
				id: 3,
				nome:'Gisele'
			}
		]},
		
		
		
	];

	
	listagem = [
		{
			id: 1,
			nome: "Lucas",
			localDeTrabalho: "local 1",
			tipoServico: "tipo 1",
			servico: "servico 1",
			totalDeHoras: "18:00",
			observacao: "observa 1",
			turno: "turno 1"
		},
		{
			id: 2,
			nome: "Bruno",
			localDeTrabalho: "local 2",
			tipoServico: "tipo 2",
			servico: "servico 2",
			totalDeHoras: "18:00",
			observacao: "observa 2",
			turno: "turno 2"
		},
		{
			id: 3,
			nome: "Carlos",
			localDeTrabalho: "local 3",
			tipoServico: "tipo 3",
			servico: "servico 3",
			totalDeHoras: "18:00",
			observacao: "observa 3",
			turno: "turno 3"
		},
		{
			id: 4,
			nome: "Thiago",
			localDeTrabalho: "local 4",
			tipoServico: "tipo 4",
			servico: "servico 4",
			totalDeHoras: "18:00",
			observacao: "observa 4",
			turno: "turno 4"
		},
		{
			id: 5,
			nome: "Renato",
			localDeTrabalho: "local 5",
			tipoServico: "tipo 5",
			servico: "servico 5",
			totalDeHoras: "18:00",
			observacao: "observa 5",
			turno: "turno 5"
		},

	];

	actions = [
		{
			id: 0,
			name: 'Gerenciar item',
			icon: 'fas fa-cogs',
			action: item => this.handleGerenciar(item),
		},
	];

	async componentDidMount(){
		const { data } = await tituloService.filtro({page: 1, pageSize: NUMERO_ITENS_POR_PAGINA});
		const { data: situacoes } = await situacaoService.lista();
		this.setState({ situacoes });
		this.setState({data});
	}

	btnNovoTitulo() {
		return (
			<a href="#" className="btn btn-success btn-sm btn-block" role="button">
				<i className="glyphicon glyphicon-edit"></i> Novo Titulo
			</a>
		);
	}

	renderRows = (listagem) => {
        const list = listagem || []

        return list.map(apontamento => (

                <tr key={apontamento._id}>
                   	<td><input type="text" className="input-table" value={apontamento.nome}></input></td> 
					<td><input type="text" className="input-table" value={apontamento.localDeTrabalho}></input></td>
					<td><input type="text" className="input-table" value={apontamento.tipoServico}></input></td>
					<td><input type="text" className="input-table" value={apontamento.servico}></input></td>
					<td><input type="text" className="input-table" value={apontamento.totalDeHoras}></input></td>
					<td><input type="text" className="input-table" value={apontamento.observacao}></input></td>
					<td><input type="text" className="input-table" value={apontamento.turno}></input></td>
					<td className="text-center"><a ><i class="fas fa-trash text-center"></i></a></td>
					
                </tr>
		))
    };

	tableContent() {
		return (
			<Table
				align='left'
				showPaginate={this.state.data.total > NUMERO_ITENS_POR_PAGINA}
				totalElements={this.state.data.total}
				columns={this.columns}
				actions={this.actions}
				data={this.state.data.items}
				totalPages={this.state.data.pageCount}
				currentPage={this.state.data.page}
				totalItemPages={this.state.data.pageSize}
				onChangePage={page => this.handlePaginacao(page)}
				emptyMessage="Nenhum item encontrado."
				emptyColSpan={this.columns ? this.columns.length + 1: 0}/>
		);
	};

	stylesSelect = () => {

		return  {
			option: (provided, state) => ({
				...provided,
				borderBottom: '1px dotted pink',
				color: state.isSelected ? 'white' : 'black',
				padding: 20
			}),
			control: (provided, state) => ({
				...provided,
				borderTop: '0px dotted pink',
				borderLeft: '0px dotted pink',
				borderRight: '0px dotted pink',
				color: state.isSelected ? 'white' : 'black',
			}),
			
			singleValue: (provided, state) => {
			  const opacity = state.isDisabled ? 0.5 : 1;
			  const transition = 'opacity 300ms';
		  
			  return { ...provided, opacity, transition };
			}
		  }
	}

	themeSelect = (theme) => {

		return  {
			...theme,
			borderRadius: 0,
			
			colors: {
				...theme.colors,
				primary25: 'hotpink',
				primary: 'black',
			}
		}
	}

	selectEquipes = () => {

		let options = [];

		this.equipes.map(function(equipe, i){
			 options.push({value:equipe.id, label:equipe.nome})
		})

		return options;
	}
	

	dadosGerais = () => {

		return (

			<CardStyle className="card border-primary">
				<div className="card-header">
					Dados Gerais
				</div>
				<div className="card-body">
					<div className="form-row dados-gerais-apontamento col-md-12">
						<div className="col-md-4">
							<label htmlFor="data" className="bmd-label-floating">Data</label>
							<input name="data" autoComplete="off" type="date" min="1000-01-01" max="3000-12-31" name="data" className='form-control' />
						</div>
						<div className="col-md-4">

						</div>
						<div className="select-container col-md-4">
							<label htmlFor="password" className="bmd-label-floating">Equipe</label>
							<Select id="sl"  
								options={this.selectEquipes()}
								styles={this.stylesSelect()}
								theme={theme => ({
								...theme,
								borderRadius: 0,
								colors: {
									...theme.colors,
									primary25: '#85D7AE',
									primary: '#75C59C',
								}
								})}
							/>
						</div>
					</div>
				</div>
			</CardStyle>

		)
	}

	submitApontamento = () => {

		return (

			<CardStyle className="card border-primary">
				<div className="card-header">
					Dados do apontamento
				</div>
				<div className="card-body">
					<section id="tabs" className="project-tab">
						<div className="row">
							<div className="col-md-12">
								<ul className="nav nav-tabs" role="tablist">
									<li className="nav-item">
										<a className="nav-item nav-link active"  id="nav-servicos-tab" href="#servicos" role="tab" data-toggle="tab"  aria-controls="nav-servicos" aria-selected="true">Serviço</a>
									</li>
									<li className="nav-item">
										<a className="nav-link" href="#perda" role="tab" data-toggle="tab" >Perda</a>
									</li>
								</ul>
								<div className="tab-content tap-content-auto-height mb-4">
									<div className="tab-pane fade show active" id="servicos" role="tabpanel" >
										<div className="col-md-12 flex">
											<div className="col-md-3">
												<label htmlFor="membrosEquipe" className="bmd-label-floating">Membros da equipe</label>
												<Select id="sl"  
													options={this.selectEquipes()}
													styles={this.stylesSelect()}
													theme={theme => ({
													...theme,
													borderRadius: 0,
													colors: {
														...theme.colors,
														primary25: '#85D7AE',
														primary: '#75C59C',
													}
													})}
												/>
											</div>
											<div className="col-md-3">
												<label htmlFor="localDeTrabalho" className="bmd-label-floating">Local de trabalho</label>
												<Select id="sl"  
													options={this.selectEquipes()}
													styles={this.stylesSelect()}
													theme={theme => ({
													...theme,
													borderRadius: 0,
													colors: {
														...theme.colors,
														primary25: '#85D7AE',
														primary: '#75C59C',
													}
													})}
												/>
											</div>
											<div className="col-md-3">
												<label htmlFor="turno" className="bmd-label-floating">Turno</label>
												<Select id="sl"  
													options={this.selectEquipes()}
													styles={this.stylesSelect()}
													theme={theme => ({
													...theme,
													borderRadius: 0,
													colors: {
														...theme.colors,
														primary25: '#85D7AE',
														primary: '#75C59C',
													}
													})}
												/>
											</div>
											<div className="col-md-3">
												<label htmlFor="servico" className="bmd-label-floating">Serviço</label>
												<Select id="sl"  
													options={this.selectEquipes()}
													styles={this.stylesSelect()}
													theme={theme => ({
													...theme,
													borderRadius: 0,
													colors: {
														...theme.colors,
														primary25: '#85D7AE',
														primary: '#75C59C',
													}
													})}
												/>
											</div>
										</div>
										<div className="col-md-12 flex mt-5">
											<div className="col-md-3">
												<label htmlFor="totalDeHoras" className="bmd-label-floating">Total de horas</label>
												<Select id="sl"  
													options={this.selectEquipes()}
													styles={this.stylesSelect()}
													theme={theme => ({
													...theme,
													borderRadius: 0,
													colors: {
														...theme.colors,
														primary25: '#85D7AE',
														primary: '#75C59C',
													}
													})}
												/>
											</div>
											<div className="col-md-3">
												<label htmlFor="descricao" className="bmd-label-floating">Descrição</label>
												<input autoComplete="on" type="text" name="descricao" className='form-control' />
											</div>
											<div className="col-md-3">
												<label htmlFor="hectares" className="bmd-label-floating">Hectares</label>
												<input autoComplete="on" type="number" name="hectares" className='form-control' />
											</div>
											<div className="col-md-3">
												<label htmlFor="statusServico" className="bmd-label-floating">Status do Serviço</label>
												<Select id="sl"  
													options={this.selectEquipes()}
													styles={this.stylesSelect()}
													theme={theme => ({
													...theme,
													borderRadius: 0,
													colors: {
														...theme.colors,
														primary25: '#85D7AE',
														primary: '#75C59C',
													}
													})}
												/>
											</div>
										</div>
										
										<div className="col-md-12 flex mt-4">
											<div className="col-md-4"><hr className="mt-3"/></div>
											<div className="col-md-4 text-center">
												<button className="btn btn-padrao" type="button" onClick={[]} ><i class="fas fa-plus mr-2"></i>Adicionar</button>
											</div>
											<div className="col-md-4"><hr className="mt-3"/></div>
										</div>
										
									</div>
									<div role="tabpanel" className="tab-pane fade" id="perda">bbb
											{/* inserir aqui o codigo do componente de perda */}
									</div>
								</div>
							</div>
						</div>
					</section>
				</div>
			</CardStyle>

			

		)
	}

	tableApontamentos = () => {

		return (

			<CardStyle className="card border-primary">
				<div className="card-header">
					Serviços e perdas cadastrados
				</div>
				<div className="card-body">
					<table class="table table-striped table-apontamento">
						<thead>
							<tr>
								<th scope="col">Nome</th>
								<th scope="col">Local de trabalho</th>
								<th scope="col">Tipo de serviço</th>
								<th scope="col">Serviço</th>
								<th scope="col">Total de horas</th>
								<th scope="col">Observação</th>
								<th scope="col">Turno</th>
								<th scope="col">Ações</th>
							</tr>
						</thead>
						<tbody>
							{this.renderRows(this.listagem)}
						</tbody>
					</table>
				</div>
			</CardStyle>

			

		)
	}

	render() {
		return (
			<>
				<Title>Cadastro Apontamentos colaboradores</Title>
				<div className="row">
					<div className="col-sm-12 col-md-12">
						<div className="card-deck">
							{this.dadosGerais()}
						</div>
						<div className="card-deck mt-3">
							{this.submitApontamento()}
						</div>
						<div className="card-deck  mt-3">
							{this.tableApontamentos()}
						</div>
					</div>
				</div>
			</>
		);
	}
}

export default withRouter(ApontamentoColaboradorCadastro);
