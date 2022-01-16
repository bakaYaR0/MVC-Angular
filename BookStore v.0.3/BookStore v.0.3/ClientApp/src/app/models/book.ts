export class Book {
  constructor(
    public id?: number,
    public isbn?: string,
    public title?: string,
    public subtitle?: string,
    public author?: string,
    public publisher?: string,
    public pages?: number,
    public value?: number,
    public amountInStock?: number,
    public description?: string) { }
}
