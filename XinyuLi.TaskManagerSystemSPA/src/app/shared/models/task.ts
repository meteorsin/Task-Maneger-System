export interface Task {
    id: number;
    userId?: number;
    title: string;
    description: string;
    duedate: string;
    priority:string;
    remarks:string;
}