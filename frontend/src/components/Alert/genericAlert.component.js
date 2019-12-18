import React from 'react';
/*
Componente de Alerta Basico Generico

Recebe os seguintes parametros por props:

- body: conteudo do card, em geral um string texto
- type: tipo do card, usado para configurar o estilo do card
essa propriedade aceita os tipos primary,secondary,
success,danger, warning, info, light, dark
 */

function GenericAlert(props) {
	const {
		body,
		type,
	} = props;
	console.log(type);
	return (
		<React.Fragment>
			<div className={`alert alert-${type}`} role='alert'>
				{body}
			</div>
		</React.Fragment>
	);
}
export default GenericAlert;
