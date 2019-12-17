import React from "react";

import { DropdownStyle } from "./dropdown.style";

const Dropdown = props => 
            <div className="btn-group">
                <button type="button" className="btn btn-default">
                    <div className="checkbox" style="margin: 0;">
                        {props.label}
                    </div>
                </button>
                <button type="button" className="btn btn-default dropdown-toggle" data-toggle="dropdown">
                    <span className="caret"></span><span className="sr-only">Toggle Dropdown</span>
                </button>
                <ul className="dropdown-menu" role="menu">
                    {props.children}
                </ul>
            </div>;

export default Dropdown;