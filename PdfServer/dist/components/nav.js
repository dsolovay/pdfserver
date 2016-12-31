"use strict";
var React = require("react");
exports.Nav = function (props) {
    return (React.createElement("div", { className: "pure-u" },
        React.createElement("div", { className: "nav-inner" },
            React.createElement("button", { className: "primary-button pure-button" }, "New Template"),
            React.createElement("div", { className: "pure-menu" },
                React.createElement("ul", { className: "pure-menu-list" },
                    React.createElement("li", { className: "pure-menu-item" },
                        React.createElement("a", { href: "#", className: "pure-menu-link" }, props.item1)),
                    React.createElement("li", { className: "pure-menu-item" },
                        React.createElement("a", { href: "#", className: "pure-menu-link" }, props.item2)))))));
};
//# sourceMappingURL=nav.js.map