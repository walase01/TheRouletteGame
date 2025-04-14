export interface ErrorDetail {
    code: number; 
    message: string;
}
  
export interface AppResponse<T> {
    succeeded: boolean;
    message: string;
    errors: ErrorDetail[];
    result?: T;
}
  