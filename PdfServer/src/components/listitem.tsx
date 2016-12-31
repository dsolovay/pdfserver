import * as React from "react";

export interface ListItemProps {
    name: string;
    description: string;
    tags: string;
}

export interface ListItemState {
    selected: boolean;
    active: boolean;
}

export class ListItem extends React.Component<ListItemProps, ListItemState> {
    constructor() {
        super();

        this.state = {
            selected: false,
            active: true
        };
    }

    render() {
        return (
            <div className={"list-item " + (this.state.selected ? "list-item-selected " : "") + (this.state.active ? "list-item-unread " : "") + "pure-g"}
                onClick={() => this.setState({ selected: !this.state.selected, active: this.state.active })}>
                <div className="pure-u">
                    <img width="64" height="64" className="list-avatar" src="/img/nodejs-512.png" />
                </div>

                <div className="pure-u-3-4">
                    <h5 className="list-name">{this.props.name}</h5>
                    <h4 className="list-subject">{this.props.tags}</h4>
                    <p className="list-desc">
                        {this.props.description}
                    </p>
                </div>
            </div >
        );
    }
}