import { Register } from './register';

describe('Register', () => {
  it('should create an instance', () => {
    expect(new Register('Kapil','Sharma','kapil@gmail.com','kapil26','test@123')).toBeTruthy();
    expect(Register).toBeTruthy();
  });
});

