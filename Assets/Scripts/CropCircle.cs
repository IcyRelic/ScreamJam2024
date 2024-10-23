using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class CropCircle : MapInteractable
{

    /** References **/
    [SerializeField] private GameObject endingScreen;
    [SerializeField] private Image backgroundImage;
    [SerializeField] private Image playerImage;
    [SerializeField] private Image bossImage;
    [SerializeField] private Image itemImage;
    [SerializeField] private TMP_Text resultText;
    [SerializeField] private TMP_Text endingText;
    [SerializeField] private TMP_Text notesText;
    [SerializeField] private TMP_Text completionText;
    [SerializeField] private Button newGameButton;
    [SerializeField] private Button mainMenuButton;

    [SerializeField] private Sprite[] itemSprites;
    private Animator notesAnim;
    private Animator itemImageAnim;
    private Animator bgAnim;
    private Animator playerAnim;
    private Animator bossAnim;
    private Animator resultAnim;
    private Animator endingAnim;
    private Animator completionAnim;

    /** Variables **/
    private List<EndingNote> endingNotes;
    private const float timeLimit = 600f;
    private float timeElapsed = 0f;

    private int endingNumber = 0;

    private bool defeatedBoss = false;

    public override void Awake()
    {
        notesAnim = notesText.GetComponent<Animator>();
        itemImageAnim = itemImage.GetComponent<Animator>();
        bgAnim = backgroundImage.GetComponent<Animator>();
        playerAnim = playerImage.GetComponent<Animator>();
        bossAnim = bossImage.GetComponent<Animator>();
        resultAnim = resultText.GetComponent<Animator>();
        endingAnim = endingText.GetComponent<Animator>();
        completionAnim = completionText.GetComponent<Animator>();

        
        endingScreen.GetComponent<CanvasGroup>().alpha = 0;

        base.Awake();
    }

    protected override void Interact()
    {
        endingScreen.SetActive(true);
        endingScreen.GetComponent<CanvasGroup>().alpha = 1;

        timeElapsed = Time.timeSinceLevelLoad;

        completionText.text = "Completion Time: " + Mathf.Floor(timeElapsed / 60) + "m " + Mathf.Floor(timeElapsed % 60) + "s";


        DraftEndingNotes();

        FindObjectOfType<AudioManager>().StopAll();
        FindObjectOfType<AudioManager>().ChangeMusic(2);


        StartCoroutine(FadeInEndingScreen());
    }

    IEnumerator FadeInEndingScreen()
    {   
        
        //fade the backgound in
        bgAnim.SetBool("Visible", true);
        yield return new WaitForSeconds(1f);
        resultAnim.SetBool("Visible", true);
        yield return new WaitForSeconds(1f);
        endingAnim.SetBool("Visible", true);
        completionAnim.SetBool("Visible", true);
        yield return new WaitForSeconds(1f);
        
        playerAnim.SetBool("Visible", true);
        bossAnim.SetBool("Visible", true);
        yield return new WaitForSeconds(1f);

        StartCoroutine(DisplayEndingNotes());
    }

    IEnumerator NotesFinished()
    {
        bossAnim.SetBool("Visible", false);
        playerAnim.SetBool("Visible", false);
        notesAnim.SetBool("Visible", false);
        itemImageAnim.SetBool("Visible", false);


        yield return new WaitForSeconds(1f);
        StartCoroutine(FadeInButtons());
        
    }

    private IEnumerator FadeInButtons()
    {

        yield return new WaitForSeconds(1f);

        float elapsedTime = 0.0f;
        float fadeDuration = 2f;

        Image[] images = new Image[] {newGameButton.GetComponent<Image>(), mainMenuButton.GetComponent<Image>()};
        TextMeshProUGUI[] texts = new TextMeshProUGUI[] {newGameButton.GetComponentInChildren<TextMeshProUGUI>(), mainMenuButton.GetComponentInChildren<TextMeshProUGUI>()};

        while (elapsedTime < fadeDuration)
        {
            float alpha = Mathf.Lerp(0f, 1f, elapsedTime / fadeDuration);

            foreach (Image img in images)
            {
                img.color = new Color(img.color.r, img.color.g, img.color.b, alpha);
            }

            foreach (TextMeshProUGUI text in texts)
            {
                text.alpha = alpha;
            }

            elapsedTime += Time.deltaTime;

            yield return null;
        }
        endingScreen.GetComponent<CanvasGroup>().interactable = true;
        endingScreen.GetComponent<CanvasGroup>().blocksRaycasts = true;
    }

    IEnumerator DisplayEndingNotes()
    {
        yield return new WaitForSeconds(1f);
        
        foreach (EndingNote note in endingNotes)
        {
            if(note.itemImage != null)
            {
                itemImage.sprite = note.itemImage;
                itemImageAnim.SetBool("Visible", true);
                
            }

            if(note.fadeBoss)
            {
                bossAnim.SetBool("Visible", false);
            }

            if(note.fadePlayer)
            {
                playerAnim.SetBool("Visible", false);
            }

            foreach (string line in note.notes)
            {
                notesText.text = line;
                notesAnim.SetBool("Visible", true);
                yield return new WaitForSeconds(2f);
                notesAnim.SetBool("Visible", false);

                if(note.itemImage != null && line == note.notes[note.notes.Length - 1])
                {
                    itemImageAnim.SetBool("Visible", false);
                }

                yield return new WaitForSeconds(1f); 
            }
        }
        StartCoroutine(NotesFinished());
        notesText.text = "";
        notesText.alpha = 0;
    }

    private void DraftEndingNotes()
    {
        endingNotes = new List<EndingNote>
        {
            new EndingNote
            {
                notes = new string[]
                {
                    "When you first arrived, you quickly realized that you were not alone.",
                    "Sadly, your friends were nowhere to be found, the house was empty.",
                    "But you were not afraid. You were determined to find out what was going on.",
                }
            },
            new EndingNote
            {
                itemImage = itemSprites[4],
                notes = new string[]
                {
                    "You searched the house, and found a diary page. It was a clue.",
                }
            },
            new EndingNote
            {
                notes = new string[]
                {
                    "You found a locked door, and you needed a key to open it.",
                }
            },
            new EndingNote
            {
                itemImage = itemSprites[4],
                notes = new string[]
                {
                    "Inside, you found the recipe for a spell that would help you.",
                }
            }

            
        };

        if(ProgressionManager.Instance.HasSpell)
        {
            endingNotes.Add(new EndingNote
            {
                itemImage = itemSprites[5],
                fadeBoss = true,
                notes = new string[]
                {
                    "You found the ingredients for the spell...",
                    "You casted the spell, and you felt a surge of power.",
                }
            });

            endingNotes.Add(new EndingNote
            {
                notes = new string[]
                {
                    "You began to see the boss stuggling, and you knew you had a chance."
                }
            });

            endingNotes.Add(new EndingNote
            {
                fadeBoss = true,
                notes = new string[]
                {
                    "The boss has been overwhelmed by your spell, and you defeated it.",
                    "Your friends were safe, and you had saved the day."
                }
            });
        } 
        else
        {
            endingNotes.Add(new EndingNote
            {
                notes = new string[]
                {
                    "You searched high and low, but you could not find the ingredients for the spell.",
                }
            });

            
            if(Time.timeSinceLevelLoad > timeLimit)
            {
                Debug.Log("Out of Time");
                endingNumber = 3;
                resultText.text = "You Lose!";
                endingText.text = "Out of Time - (Ending 3 of 3)";
                endingNotes.Add(new EndingNote
                {
                    notes = new string[]
                    {
                        "You came to find your friends, but you were too late.",
                        "The boss was nowhere to be found.",
                        "You were defeated, and your friends were lost."
                    }
                });
                return;
            }
            else 
            {
                defeatedBoss = SimulateBossFight();

                if(defeatedBoss)
                {
                    Debug.Log("Defeated Boss");
                    endingNumber = 1;
                    resultText.text = "You Win!";
                    endingText.text = "Good Ending - (Ending 1 of 3)";
                } 
                else
                {
                    Debug.Log("Lost to Boss");
                    endingNumber = 2;
                    resultText.text = "You Lose!";
                    endingText.text = "Bad Ending - (Ending 2 of 3)";

                }
            }

            

        }

        
    }


    private bool SimulateBossFight()
    {
        float accuracy = ProgressionManager.Instance.GetWeaponAccuracy();
        float damage = ProgressionManager.Instance.GetWeaponDamage();
        int rounds = 5;

        if(!ProgressionManager.Instance.BaseballBat)
        {
            endingNotes.Add(new EndingNote
            {
                notes = new string[]
                {
                    "You faced the boss, but you were not prepared.",
                    "You tried to fight, but you were no match for the boss.",
                    "You were defeated, and your friends were lost."
                }
            });
            return false;
        }

        float bossHP = 100f;


        for(int i = 0; i < rounds; i++)
        {
            float roll = Random.Range(0f, 1f);
            Debug.Log($"Roll: {roll} Accuracy: {accuracy}");
            if(roll < accuracy)
            {
    
                bossHP -= (int)damage;
                Debug.Log($"HIT Boss HP: {bossHP}");
            }
        }

        bool won = bossHP <= 0;

        int spriteId = ProgressionManager.Instance.Weapon3 ? 1 : ProgressionManager.Instance.Weapon2 ? 2 : 3;

        if(won)
        {
            endingNotes.Add(new EndingNote
            {
                itemImage = itemSprites[spriteId],
                fadeBoss = true,
                notes = new string[]
                {
                    "You faced the boss, and you were prepared.",
                    "You fought bravely, and you defeated the boss.",
                    "Your friends were safe, and you had saved the day."
                }
            });
        } 
        else
        {
            endingNotes.Add(new EndingNote
            {
                itemImage = itemSprites[spriteId],
                notes = new string[]
                {
                    "You faced the boss, but your weapon was not strong enough.",
                    "You tried to fight, but you were no match for the boss.",
                    "You were defeated, and your friends were lost."
                }
            });
        }
        return won;
    }
}

class EndingNote
{
    public Sprite itemImage;
    public string[] notes;

    public bool fadeBoss = false;
    public bool fadePlayer = false;
}