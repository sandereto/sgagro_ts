import PropTypes from 'prop-types';
import React from 'react';
import { ButtonStyle } from './button.style';
/*
Componente de Botão

Recebe os seguintes parametros por props:

disabled - Desabilitar o click do botão ;
onClick - Função que será chamada ao ser chamado o evento de click no botão ;
primary - Define o background primário do botão, caso true;
className - Define a classe do botão;
type - Define o tipo do botão ;
cancel - 
icon - Define o ícone do botão;
text - Define o texto do botão ;
children - 
*/
const Button = (props) => {
	const {
		disabled,
		onClick,
		primary,
		className,
		type,
		cancel,
		icon,
		text,
		children,
	} = props;

	/*
		Retorna o estilo do botão de acordo com as propriedades passasdas
	*/
	return (
		<ButtonStyle
			disabled={disabled}
			onClick={onClick}
			primary={primary.toString()}
			className={className}
			type={type}
			cancel={cancel.toString()}
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
		</ButtonStyle>
	);
};
/*
	Define o tipo das propriedades a serem recebidas;
*/
Button.propTypes = {
	disabled: PropTypes.bool,
	onClick: PropTypes.func,
	primary: PropTypes.bool,
	className: PropTypes.string,
	type: PropTypes.string.isRequired,
	cancel: PropTypes.bool,
	icon: PropTypes.string,
	text: PropTypes.string,
	children: PropTypes.node,
};
/*
	Define o valor da propriedade padrão, caso nenhuma propriedade seja passada;
*/
Button.defaultProps = {
	disabled: false,
	onClick: () => null,
	primary: false,
	className: '',
	cancel: false,
	icon: '',
	text: '',
	children: '',
};

export default Button;
