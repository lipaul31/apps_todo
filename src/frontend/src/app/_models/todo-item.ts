export interface TodoItem {
    id: number;
    description: string;
    state: boolean;
}

export interface TodoItemAdd {
    description: string;
}