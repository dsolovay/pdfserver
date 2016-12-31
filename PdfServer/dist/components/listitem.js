"use strict";
var __extends = (this && this.__extends) || function (d, b) {
    for (var p in b) if (b.hasOwnProperty(p)) d[p] = b[p];
    function __() { this.constructor = d; }
    d.prototype = b === null ? Object.create(b) : (__.prototype = b.prototype, new __());
};
var React = require("react");
var ListItem = (function (_super) {
    __extends(ListItem, _super);
    function ListItem() {
        var _this = _super.call(this) || this;
        _this.state = {
            selected: false,
            active: true
        };
        return _this;
    }
    ListItem.prototype.render = function () {
        var _this = this;
        return (React.createElement("div", { className: "list-item " + (this.state.selected ? "list-item-selected " : "") + (this.state.active ? "list-item-unread " : "") + "pure-g", onClick: function () { return _this.setState({ selected: !_this.state.selected, active: _this.state.active }); } },
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