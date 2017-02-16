"use strict";
var __extends = (this && this.__extends) || function (d, b) {
    for (var p in b) if (b.hasOwnProperty(p)) d[p] = b[p];
    function __() { this.constructor = d; }
    d.prototype = b === null ? Object.create(b) : (__.prototype = b.prototype, new __());
};
var React = require("react");
var ListItem = (function (_super) {
    __extends(ListItem, _super);
    function ListItem(props) {
        var _this = _super.call(this, props) || this;
        _this.handleChange = _this.handleChange.bind(_this);
        return _this;
    }
    ListItem.prototype.handleChange = function (event) {
        //this.props.onClick(event);
    };
    ListItem.prototype.render = function () {
        var selected = this.props.selected ? "list-item-selected " : "";
        var active = this.props.active ? "list-item-unread " : "";
        return (React.createElement("div", { className: "list-item " + selected + active + "pure-g", onClick: this.handleChange, id: "list-item-" + this.props.id },
            React.createElement("div", { className: "pure-u" },
                React.createElement("img", { width: "64", height: "64", className: "list-avatar", src: "/img/nodejs-512.png" })),
            React.createElement("div", { className: "pure-u-3-4" },
                React.createElement("h5", { className: "list-name" }, this.props.name),
                React.createElement("h4", { className: "list-subject" }, this.props.tags),
                React.createElement("p", { className: "list-desc" }, this.props.description))));
    };
    return ListItem;
}(React.Component));
exports.ListItem = ListItem;
//# sourceMappingURL=listitem.js.map