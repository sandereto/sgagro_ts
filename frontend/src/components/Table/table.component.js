import React, { Component } from 'react';
import { NUMERO_ITENS_POR_PAGINA } from '../../constants';
import Pagination from '../Pagination/pagination.component';
import { TableStyle, TdStyle } from './table.style';
import Tbody from './tbody.component';
import Thead from './thead.component';

export default class Table extends Component {
	/* Função para exibir numeros dos resultados de cada página */
	getCurrentItems() {
		/* Retorna até qual item está sendo exibindo na página
			Ex: Exibindo de 1 a 15 (15 no caso é o currentItem)
				Exibindo de 16 a 18 (18 no caso é o currentItem)

			É usado também no calculo do item inicial de cada página
			Ex: Exibindo de 1 a 15
				(1 no caso é o (currentItem) - (o total de items vindos do backend - 1))

				Exibindo de 16 a 18 (16 no caso é o
				(currentItem) - (o total de items vindos do backend - 1))

			Se quiser alterar quantos serão exibidos por página,
			basta mudar o NUMERO_ITENS_POR_PAGINA, para o valor que você quiser,
			lembrando que tudo será afetado, não só esse componente
			ATENÇÃO: ISSO NÃO MUDA A PAGINAÇÃO, APENAS O 'EXIBINDO RESULTADOS' DA PÁGINA
		*/
		const { totalItemPages, currentPage } = this.props;
		// Verificação feita para garantir que currentPage sempre seja um valor positivo
		const positiveCurrentPage = currentPage > 0 ? currentPage : 0;
		const currentItems = totalItemPages
			? (NUMERO_ITENS_POR_PAGINA * (positiveCurrentPage + 1))
			- (NUMERO_ITENS_POR_PAGINA - totalItemPages)
			: 0;
		return currentItems;
	}

	exibirTotal = (columns, data) => {
		const result = [];
		result.push(
			<TdStyle>
				<b>Total geral: </b>
			</TdStyle>,
		);
		for (let i = columns.length - 2; i > 0; i -= 1) {
			result.push(<TdStyle />);
		}
		/* Soma a coluna das quantidades do estoque e obtem o total */
		const quantidadeTotal = data.reduce((prev, elem) => prev + elem.quantidade, 0);
		result.push(
			<TdStyle style={{ textAlign: 'right' }}>
				<b>{quantidadeTotal}</b>
			</TdStyle>,
		);
		return result;
	}

	render() {
		const {
			props: {
				align,
				className,
				columns,
				data,
				actions,
				onClick,
				onChangePage,
				totalPages,
				currentPage,
				showPages,
				acoesSingleButton,
				emptyMessage,
				emptyColSpan,
				showTotal,
				totalElements,
				showPaginate,
				totalItemPages,
				trClass,
			},
		} = this;

		return (
			<div className='container'>
				<div>
					<TableStyle align={align} className={className}>
						<Thead
							columns={columns}
							acoesSingleButton={acoesSingleButton}
							actions={actions}
						/>
						<Tbody
							emptyColSpan={emptyColSpan}
							emptyMessage={emptyMessage}
							data={data}
							onClick={onClick}
							columns={columns}
							acoesSingleButton={acoesSingleButton}
							actions={actions}
							showTotal={showTotal}
							exibirTotal={this.exibirTotal}
							trClass={trClass}
						/>

					</TableStyle>
				</div>
				<div className='row'>
					<div className='col-md-4 mt-4'>
					</div>
					<div className='col-md-8'>
						<div className='ml-5'>
							{showPaginate && (
								<Pagination
									onChangePage={onChangePage}
									totalPages={totalPages}
									currentPage={currentPage}
									showPages={showPages}
								/>
							)}
						</div>
					</div>
				</div>
			</div>
		);
	}
}
