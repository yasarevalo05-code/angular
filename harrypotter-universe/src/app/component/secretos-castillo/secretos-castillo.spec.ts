import { ComponentFixture, TestBed } from '@angular/core/testing';

import { SecretosCastillo } from './secretos-castillo';

describe('SecretosCastillo', () => {
  let component: SecretosCastillo;
  let fixture: ComponentFixture<SecretosCastillo>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [SecretosCastillo]
    })
    .compileComponents();

    fixture = TestBed.createComponent(SecretosCastillo);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
