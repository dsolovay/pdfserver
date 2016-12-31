import * as React from "react";
import { ListItem, ListItemProps } from "./listitem";

export interface ListProps {

}

export interface ListState {
    items: ListItemProps[]
}

export class List extends React.Component<ListProps, ListState> {
    constructor() {
        super();

        this.state.items = Array<ListItemProps>();
    }

    render() {
        const items = this.state.items.map((props, index) => {
            return (
                <ListItem name={props.name} description={props.description} tags={props.tags} key={index} />
            );
        })

        return (
            <div>{items}</div>
        );
    }
}