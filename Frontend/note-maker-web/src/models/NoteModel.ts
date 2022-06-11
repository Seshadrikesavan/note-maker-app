export class NoteModel 
{
    id: number;
    noteTitle: string;
    noteContent: string;
    starred: boolean;
    createdTime: Date;
    modifiedTime: Date;
    
    constructor(note: Partial<NoteModel>)
    {
        Object.assign(this, note);
    }
}