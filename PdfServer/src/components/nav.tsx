import * as React from "react";

export interface NavProps {
    item1: string;
    item2: string;
}

export const Nav = function (props : NavProps) {
    return (
        <div className="pure-u">
            <div className="nav-inner">
                <button className="primary-button pure-button">New Template</button>

                <div className="pure-menu">
                    <ul className="pure-menu-list">
                        <li className="pure-menu-item"><a href="#" className="pure-menu-link">{props.item1}</a></li>
                        <li className="pure-menu-item"><a href="#" className="pure-menu-link">{props.item2}</a></li>
                    </ul>
                </div>
            </div>
        </div>
    );
};