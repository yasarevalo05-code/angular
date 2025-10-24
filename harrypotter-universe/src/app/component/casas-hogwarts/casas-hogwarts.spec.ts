import { ComponentFixture, TestBed } from '@angular/core/testing';

import { CasasHogwarts } from './casas-hogwarts';

describe('CasasHogwarts', () => {
  let component: CasasHogwarts;
  let fixture: ComponentFixture<CasasHogwarts>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [CasasHogwarts]
    })
    .compileComponents();

    fixture = TestBed.createComponent(CasasHogwarts);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
