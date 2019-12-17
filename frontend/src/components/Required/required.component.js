import PropTypes from 'prop-types';
import React from 'react';
import { ButtonPaginateStyle } from './buttonPaginate.style';

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
