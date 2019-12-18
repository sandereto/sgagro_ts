import PropTypes from 'prop-types';
import React from 'react';
import { ButtonPaginateStyle } from './buttonPaginate.style';


/*Componente Botão de paginação onde recebe-se propriedades de : 

	onClick = Evento de Click do botão;
	className = Classe do botão ;
	type = Tipo do botão ;
	isbackornext = 
	iscurrent = 
	ispagenumber = Numeração da página ;
	icon = ícone do botão ;
	text = Texto do botão ;
	children = Filhos do botão ;



*/
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
		<ButtonPaginateStyle
			onClick={onClick}
			className={className}
			type={type}
			isbackornext={isbackornext ? isbackornext : false}
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
	isbackornext: PropTypes.bool,
};
//Propriedades padrões do botão quando nenhuma props for passada;
ButtonPaginate.defaultProps = {
	className: '',
	icon: '',
	text: '',
	children: '',
	isbackornext: false
};

export default ButtonPaginate;
