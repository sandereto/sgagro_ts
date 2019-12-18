import PropTypes from 'prop-types';
import React from 'react';
import { ButtonPaginateStyle } from './buttonPaginate.style';

//Importa o componente de estilo "Component.style" e engloba todas as outras tags desse novo componente com ele,
//fazendo com que todos tenham o estilo de "Component.style"
const ButtonPaginate = (props) => {
	const {
		onClick,
		className,
		type,
		isbackornext,
		iscurrent,
		ispagenumber,
		icon,
		text,
		children,
	} = props;

	return (
		//Renderiza o botão de paginação com funções passadas por props
		<ButtonPaginateStyle
			onClick={onClick}
			className={className}
			type={type}
			isbackornext={isbackornext}
			iscurrent={iscurrent}
			ispagenumber={ispagenumber}
		>
			{icon ? (
				<span>
					<i className={icon} />
					{' '}
					{text}
				</span>
			) : (
				<span>{text}</span>
			)}
			{children}
		</ButtonPaginateStyle>
	);
};

ButtonPaginate.propTypes = {
	onClick: PropTypes.func.isRequired,
	className: PropTypes.string,
	type: PropTypes.string.isRequired,
	icon: PropTypes.string,
	text: PropTypes.string,
	children: PropTypes.node,
};

ButtonPaginate.defaultProps = {
	className: '',
	icon: '',
	text: '',
	children: '',
};

export default ButtonPaginate;
