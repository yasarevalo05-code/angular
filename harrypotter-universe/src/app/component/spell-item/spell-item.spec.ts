import { ComponentFixture, TestBed } from '@angular/core/testing';

import { SpellItem } from './spell-item';

describe('SpellItem', () => {
  let component: SpellItem;
  let fixture: ComponentFixture<SpellItem>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [SpellItem]
    })
    .compileComponents();

    fixture = TestBed.createComponent(SpellItem);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
