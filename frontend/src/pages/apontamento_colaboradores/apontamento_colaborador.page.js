import React, { Component, Fragment } from 'react';
import { withRouter } from 'react-router-dom';
import Title from '../../components/Title/title.component';
import Table from '../../components/Table/table.component';
import tituloService from '../../services/tituloService';
import situacaoService from '../../services/situacaoService';
import DateHelper from 'utils/dateHelper';
import {NUMERO_ITENS_POR_PAGINA} from '../../constants/index';

class TituloPage extends Component {
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

	render() {
		return (
			<>
				<Title acao="Novo" onclick={()=> alert('teste')}>Apontamentos colaboradores</Title>
				<div className="row">
					<div className="col-sm-12 col-md-12">
						{this.tableContent()}
					</div>
				</div>
			</>
		);
	}
}

export default withRouter(TituloPage);
