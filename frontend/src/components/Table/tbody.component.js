import React from 'react';
import * as _ from 'lodash';

import PropTypes from 'prop-types';
import StringHelper from 'utils/stringHelper';
import ObjectHelper from 'utils/objectHelper';

import Subtitle from '../Subtitle/subtitle.component';

import {
	ButtonDropdownStyle, ButtonStyle, IconStyle, TdStyle, TrStyle,
} from './table.style';
import { NUMERO_MAX_CARACTERES_LISTAGEM } from '../../constants';

// Função para caso não haja dados para serem mostrados
const EmptyMessage = ({ emptyColSpan, emptyMessage }) => (
	<TrStyle>
		<TdStyle
			colSpan={emptyColSpan}
			className='text-center'
		>
			<Subtitle>{emptyMessage}</Subtitle>
		</TdStyle>
	</TrStyle>
);

// Função para caso seja escolhido apenas um botão de ação
const SingleActionButton = ({ action, item }) => (
	<TdStyle className='text-right'>
		{action.map(actionItem => (
			<ButtonStyle
				primary
				disabled={actionItem.enabled ? !actionItem.enabled(item) : false}
				key={actionItem.id}
				className='btn btn-secondary btn-sm'
				type='button'
				onClick={() => actionItem.action(item)}
				title={actionItem.name}
			>
				<IconStyle
					className={
						actionItem.icon
					}
				/>
			</ButtonStyle>
		))}
	</TdStyle>
);

// Função para caso seja escolhido um select de ações
const MultiActionButton = ({ actions, item }) => (
	<TdStyle className='text-right'>
		<div className='dropdown'>
			<ButtonDropdownStyle
				className='btn btn-secondary btn-sm dropdown-toggle'
				type='button'
				id='menu-acao'
				data-toggle='dropdown'
				aria-haspopup='true'
				aria-expanded='false'
			>
				Ações
			</ButtonDropdownStyle>
			<div
				className='dropdown-menu'
				aria-labelledby='menu-acao'
			>
				{/* Aplica regra para renderizar o action */}
				{actions.map(actionItem => (!actionItem.checkRule || actionItem.show(item)
					? (
						<button
							disabled={actionItem.enabled ? !actionItem.enabled(item) : false}
							key={actionItem.id}
							className='dropdown-item btn-sm'
							type='button'
							onClick={() => actionItem.action(item)}
						>
							<IconStyle className={actionItem.icon} />
							{' '}
							{actionItem.name}
						</button>
					)
					: null))}
			</div>
		</div>
	</TdStyle>
);

const Tbody = ({
	acoesSingleButton,
	actions,
	columns,
	data,
	emptyColSpan,
	emptyMessage,
	exibirTotal,
	onClick,
	showTotal,
	trClass,
}) => (
	<tbody>
		{/* Verifica se há dados, se não exibe a mensagem de que não há itens */}
		{_.isEmpty(data) && (
			<EmptyMessage emptyMessage={emptyMessage} emptyColSpan={emptyColSpan} />
		)}

		{/* Caso haja dados no sistema */}
		{data && data.map(item => (
			<TrStyle className={trClass && trClass(item)} onClick={onClick} key={item.id}>

				{/* Percorre o array de objetos-colunas que criamos */}
				{columns.map((columnItem) => {
					const content = ObjectHelper.getValueByPropertyName(
						columnItem.property,
						item,
					);
					if (content !== null) {
						/*
									Abaixo testa se o item de alguma coluna é número,
									se for alinha o mesmo a direita.

									Lembrando que deve ser colocado no array de
									objetos-coluna uma propriedade 'number', com o valor
									de false ou true
								*/
						const alignField = columnItem.number ? 'text-right' : '';
						return (
							<TdStyle className={alignField} key={columnItem.id} title={content}>
								{
									!columnItem.template 
										? StringHelper.truncate(content, NUMERO_MAX_CARACTERES_LISTAGEM)
										:  columnItem.template(content)
								}
							</TdStyle>
						);
					}
					return (
						<TdStyle key={columnItem.id}>
								--
						</TdStyle>
					);
				})}

				{/* Testa se ações será apenas um botão, com uma ação */}
				{acoesSingleButton && actions && (
					<SingleActionButton action={actions} item={item} />
				)}

				{/* Testa se ações será apenas um select com várias ações */}
				{!acoesSingleButton && actions && (
					<MultiActionButton actions={actions} item={item} />
				)}
			</TrStyle>
		))}
		{showTotal === false ? null : (
			<TrStyle>
				{exibirTotal(columns, data)}
			</TrStyle>
		)}
	</tbody>
);

Tbody.propTypes = {
	/** true: botão único com ação | false: botão select com várias ações */
	acoesSingleButton: PropTypes.bool,
	/** Array de objetos das actions */
	actions: PropTypes.arrayOf(PropTypes.object),
	/** Array de objetos com as colunas: title, property e number */
	columns: PropTypes.arrayOf(PropTypes.object).isRequired,
	/** Array de objeto vindo do backend que será renderizado pela tabela */
	data: PropTypes.arrayOf(PropTypes.object),
	/** Tamanho da coluna columns + 1 */
	emptyColSpan: PropTypes.number.isRequired,
	/** Mensagem caso não haja nada cadastro, ou seja, data = [] */
	emptyMessage: PropTypes.string.isRequired,
	/** Função para exibir quantidade total de uma coluna */
	exibirTotal: PropTypes.func,
	/** Soma dos valores das colunas */
	showTotal: PropTypes.bool,
};

Tbody.defaultProps = {
	acoesSingleButton: false,
	exibirTotal: () => { },
	actions: null,
	showTotal: false,
	data: [],
};

export default Tbody;
