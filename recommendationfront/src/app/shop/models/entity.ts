
export interface Attribute {
    keyAttr: string;
    value: string;
    weight: number;
}

export interface Entity {
    name: string;
    description: string;
    indentifier: string;
    attributes: Attribute[];
}


export interface AttrEntity {

    id : number;
    keyAttr: string;
    value: string;
    weight: number;
    createdAt: string;
    updatedAt: string;
    entityId: number;
}