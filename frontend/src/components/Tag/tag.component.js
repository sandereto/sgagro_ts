import React from 'react';
import { TagStyle } from './tag.style'
// Renderiza um componente "Tag", que terá várias props dentro de um componente "Tag.Style"
const Tag = (props) => {
	return (
		<TagStyle {...props}/>
	);
};


export default Tag;
